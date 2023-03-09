using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SlidingGame : MonoBehaviour
{
    [SerializeField] private Transform gameTransform;
    [SerializeField] private Transform piecePrefab;

    private List<Transform> pieces;
    private int emptyLocation;
    private int size;
    private bool shuffling = false;
    public Sprite[] sp;

    // Create the game setup with size x size pieces.
    private void CreateGamePieces(float gapThickness) {
    // This is the width of each tile.
    sp = Resources.LoadAll<Sprite>("MiniGame/book1");
    float width = 1 / (float)size;
    for (int row = 0; row < size; row++) {
        for (int col = 0; col < size; col++) {
        Transform piece = Instantiate(piecePrefab, gameTransform);
        piece.GetComponent<Image>().sprite = sp[(size*row)+col];
        pieces.Add(piece);
        // Pieces will be in a game board going from -1 to +1.
        piece.localPosition = new Vector3(-1 + (2 * width * col) + width,
                                            +1 - (2 * width * row) - width,
                                            0);
        piece.localScale = ((2 * width) - gapThickness) * Vector3.one;
        piece.name = $"{(row * size) + col}";
        piece.GetComponent<Button>().onClick.AddListener(delegate{test(piece);});
        // We want an empty space in the bottom right.
        if ((row == size - 1) && (col == size - 1)) {
            emptyLocation = (size * size) - 1;
            piece.gameObject.SetActive(false);
        }
        }
    }
    }

    void test(Transform p){
        string name = p.name;
        int n;
        int.TryParse(name, out n);
        // Debug.Log(p.name);
        ClickImage(name);
    }
    // Start is called before the first frame update
    void Start() {
    pieces = new List<Transform>();
    size = 3;
    CreateGamePieces(0.01f);
    StartCoroutine(WaitShuffle(0.5f));
    }

    // Update is called once per frame
    void Update() {
    // Check for completion.
    // if (!shuffling && CheckCompletion()) {
    //     shuffling = true;
    //     StartCoroutine(WaitShuffle(0.5f));
    // }
    
    // On click send out ray to see if we click a piece.
    }

    private void ClickImage(string name){
        // Go through the list, the index tells us the position.
        for (int i = 0; i < pieces.Count; i++) {
            // Debug.Log(pieces[num].name);
            if (pieces[i].name == name) {
            // Check each direction to see if valid move.
            // We break out on success so we don't carry on and swap back again.
            if (SwapIfValid(i, -size, size)) { break; }
            if (SwapIfValid(i, +size, size)) { break; }
            if (SwapIfValid(i, -1, 0)) { break; }
            if (SwapIfValid(i, +1, size - 1)) { break; }
            }
        }
        if (CheckCompletion()){
            GameObject.Find("Player").transform.GetComponent<ItemPickUp>().DestroyThisOj();
        }
    }

    // colCheck is used to stop horizontal moves wrapping.
    private bool SwapIfValid(int i, int offset, int colCheck) {
    if (((i % size) != colCheck) && ((i + offset) == emptyLocation)) {
        // Swap them in game state.
        (pieces[i], pieces[i + offset]) = (pieces[i + offset], pieces[i]);
        // Swap their transforms.
        (pieces[i].localPosition, pieces[i + offset].localPosition) = ((pieces[i + offset].localPosition, pieces[i].localPosition));
        // Update empty location.
        emptyLocation = i;
        return true;
    }
    return false;
    }

    // We name the pieces in order so we can use this to check completion.
    private bool CheckCompletion() {
    for (int i = 0; i < pieces.Count; i++) {
        if (pieces[i].name != $"{i}") {
        return false;
        }
    }
    return true;
    }

    private IEnumerator WaitShuffle(float duration) {
    yield return new WaitForSeconds(duration);
    Shuffle();
    shuffling = false;
    }

    // Brute force shuffling.
    private void Shuffle() {
    int count = 0;
    int last = 0;
    while (count < (size * size * size)) {
        // Pick a random location.
        int rnd = Random.Range(0, size * size);
        // Only thing we forbid is undoing the last move.
        if (rnd == last) { continue; }
        last = emptyLocation;
        // Try surrounding spaces looking for valid move.
        if (SwapIfValid(rnd, -size, size)) {
        count++;
        } else if (SwapIfValid(rnd, +size, size)) {
        count++;
        } else if (SwapIfValid(rnd, -1, 0)) {
        count++;
        } else if (SwapIfValid(rnd, +1, size - 1)) {
        count++;
        }
    }
    }
}
