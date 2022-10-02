INCLUDE globals.ink
VAR name = "Liw"

=== Opening ===
#speaker:???
Don't judge the book by its cover.
The answers were already there.
Open and find it.
->DONE

=== SataCall ===
Hey you!!! #speaker:???
->SataFirstMet

=== SataFirstMet ===
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
Are you interested ?
    +[No]
        #speaker:Me
        Thanks but I don't interested.     
        #speaker:Sata
        Such a shame..
        Okay I'll go.
        #speaker:Ending
        Ending 0: Know Nothing
        ->DONE
    +[Yes]
        #speaker:Me
        I'll go with you.
        #speaker:Sata
        Good!!!
        We must become good friends {name}.
        ->DONE
    +[Let me think]
        I'm looking forward to it.
        ->DONE
->DONE
