INCLUDE globals.ink

-> main

=== main ===
-> Opening

=== Opening ===
#speaker:???
Don't judge the book by its cover.
The answers were already there.
Open and find it.
->SataCall

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
I..I dont' know.
->END
=== answerYourName ===
->DONE

=== SataInviteToTown ===
We're hiring many soliders.
Are you interested ?
->DONE
->END