INCLUDE tutorial_globals.ink

VAR name = "Liw"

=== Opening ===
    #speaker:???
    Don't <color=\#40FF6F>judge</color> the book by its cover.
    The answers were <b>already</b> there.
    Open and find it.
    ~readOP = true
->DONE

=== SataCall ===
Hey you!!! #speaker:??? #sound:singleFootstepInGrass
->SataFirstMet

=== SataFirstMet ===
{sataAskToJoin: -> SataAskToJoin} 
I'm Sata, a solider in Naver town. #speaker:???
What's your name ? #speaker:Sata
(...My name ?) #speaker:Me
(Why can't I remember anything...)
(What's wrong with me?)
Answer Sata "What's your name ?"
    +[I don't know]
        ->answerDontKnow
    +[Tell your name]
        ->answerYourName

=== answerDontKnow ===
    #speaker:Me
    I..I dont' know.
    #speaker:Sata
    What...
    You can't remember your name ?
    Are you okay?
    Hmmm However.
->SataInviteToTown

=== answerYourName ===
    #speaker:Me
    (But I dont' know. what's the name I will tell him ?)
    I'm {name}.
    #speaker:Sata
    Well {name} Nice to meet you.
->SataInviteToTown

=== SataInviteToTown ===
    #speaker:Sata
    I have something to talk with you.
    We're hiring many soliders.
->SataAskToJoin
        
=== SataAskToJoin ===
    #speaker:Sata
    Are you interested ?
        +[No]
            #speaker:Me
            Thanks but I don't interested.     
            #speaker:Sata
            Such a shame..
            Okay I'll go.
        +[Yes]
            #speaker:Me
            I'll go with you.
            #speaker:Sata
            Good!!!
            We must become good friends {name}.
        +[Let me think]
            I'm looking forward to it.
    - ~sataAskToJoin = true
->DONE
