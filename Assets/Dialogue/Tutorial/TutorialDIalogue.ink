INCLUDE tutorial_globals.ink
=== Opening ===
    #speaker:Me
    (ที่นี่น่าจะเป็นป่า Rache ตามที่แผนที่บอก)
    (อีกไม่นานคงจะใกล้ถึงเมือง <color=\#FF7272>Naver</color> แล้วสินะ)
    (ก่อนอื่นต้องทำยาสมานแผลก่อน น่าจะต้องไปหา <color=\#40FF6F>"Spindlewit"</color> แล้วสิ)
    (แย่หละสิ ตอนนี้ใกล้จะมืดแล้วด้วย คงต้องรีบแล้ว)
    ~readOP = true 
    #quest:0
->DONE
=== AfterUsePotion ===
    #speaker:Me
    (โอเค...น่าจะดีขึ้นแล้ว ต้องรีบไปแล้ว)
->MetWebster
=== MetWebster ===
    #speaker:Me
    (โอเค...น่าจะดีขึ้นแล้ว ต้องรีบไปแล้ว)
    (ดูเหมือนจะต้องจัดการพวกนั้นก่อนสินะ)
    #quest:4
->DONE
=== SataCall ===
    #speaker:??? #sound:singleFootstepInGrass
    เฮ้ เจ้าฮูดแดงนั้นหน่ะ!!
    #speaker:Me 
    ???
    #speaker:???
    นายนั่นแหละ ช่วยมานี่ทีสิ
->DONE

=== SataFirstMet ===
    {toldName: ->GoToNaver}
    #speaker:???
    พอดีข้าได้รับบาดเจ็บจากแมงมุงในป่านี้หนะ..กัดเจ็บเป็นบ้า..
    เจ้าพอจะช่วยข้าหน่อยได้หรือไม่ ข้าต้องการยาที่ใช้สมานแผลสักหน่อย
        +[ได้เลย]
    - ขอบคุณเจ้ามาก ข้าจะไม่ลืมบุญคุณนี้แน่นอน
    ว่าแต่ข้ายังไม่รู้จักชื่อของเจ้าเลย
    เจ้าชื่อว่าอะไรหรอ
        +[บอกชื่อ]
            ->answerYourName
        +[ไม่บอกชื่อ]
            ->answerDontKnow

=== answerDontKnow ===
    #speaker:???
    (เจ้านี้ดูไม่ไว้ใจข้าเลยนะ แต่ก็เอาเถอะ) 
    (ข้าจะเรียกว่า <color=\#FFD495>"เจ้าหมวกแดง"</color> แล้วกัน)
    ~name = "เจ้าหมวกแดง"
->SataIntroduction

=== answerYourName ===
    #speaker:???
    เจ้าชื่อว่าอะไรเหรอ?
    #action:GetPlayerName
->DONE
== SataRecallName ==
    ว้าว!! ชื่อเท่ดีนิ เหมาะกับเจ้าดี {name}
->SataIntroduction
=== SataIntroduction ===
    ~toldName = true
    #speaker:Sata
    ส่วนข้า..ข้ามีนามว่า <color=\#FFD495>"Sata"</color> ข้าเป็นทหารหน่วยลาดตระเวนเมือง <color=\#FF7272>Naver</color> ที่คอยดูแลความปลอดภัยของบ้านเมืองนี้ 
    ก่อนหน้านี้ข้าเห็นเจ้าถือแผนที่มายังเมือง <color=\#FF7272>Naver</color> ข้าจึงอยากจะถามว่าเจ้ามาที่เมืองนี้มีธุระอะไรหรือเปล่า??
        +[บอกเหตุผล]
        #speaker:Me
            ข้าสูญเสียความทรงจำทุกอย่าง สิ่งที่ข้าจำได้มีเพียงคำพูดหนึ่งที่อยู่ในหัวตลอด
            ข้ารู้ตัวอีกทีก็อยู่ที่หมู่บ้านเล็ก ๆ ในหุบเขาหนึ่งที่ห่างจากที่นี่ไกลมาก 
            ไม่มีใครรู้จักข้า และไม่มีใครสามารถช่วยกู้ความทรงจำข้าได้เลย ข้าจึงออกเดินทาง และได้ยินชาวบ้านบอกให้ลองไปขอความช่วยเหลือจากกษัตริย์แห่งสติปัญญา อยู่ที่เมือง <color=\#FF7272>Naver</color>) 
            ข้าจึงได้เดินทางมามาที่นี่
    #speaker:Sata
    - ถ้ากษัตริย์ที่เจ้าผู้ถึงคือ กษัตริย์ <color=\#FFD495>Armon</color> ละก็ ข้าว่า…เขาคงช่วยไม่ได้แล้วล่ะ 
    #speaker:Me
    ทำไมล่ะ
    #speaker:Sata
    คนที่เจ้าตามหาได้เสียชีวิตไปแล้วเมื่อไม่นานมานี้นี่เอง ทำให้ในเมืองเกิดเรื่องวุ่นมากมายเลยล่ะ ไว้ข้าจะเล่าให้ฟัง
    ตอนนี้ใกล้จะมืดแล้วข้าว่ารีบไปจากที่นี่ก่อนดีกว่า
    ข้าจะพาเจ้าไปพักที่เมือง <color=\#FF7272>Naver</color> ก่อน แถวนี้อันตรายเกินไป
    !!!
    แย่ละสิ...
    ข้าลืมไปว่าจะต้องจัดการ <color=\#FFBD39>Webster</color> บริเวณทางเข้าเมือง 
    ยังไม่เรียบร้อยเลย โดนแม่ทัพดุแน่
    เจ้าพอจะช่วยข้าได้หรือไม่ คราวนี้ข้ามีค่าจ้างให้ รวมค่าที่เจ้าได้ช่วยข้าไว้
    เจ้าสนใจไหม
        +[ยอมรับ]
        #quest:5
        ข้าจะรอเจ้านะ
        ->DONE
        +[ปฏิเสธ]
        งั้นเหรอ ไม่เป็นไร
        #event:GoToNaver
        ข้าจะรอเจ้าตรงนี้ พร้อมเดินทางเมื่อไหร่ก็บอกนะ
        ->DONE
->DONE
        

=== FinishedWebsterQ ===
    #speaker:Sata
    ได้มาแล้วเหรอ ขอบคุณเจ้ามาก ๆ 
    -> GoToNaver
=== GoToNaver ===
    #speaker:Sata
    เจ้าพร้อมจะออกเดินทางหรือยัง?
    +[ไปเลย]
        เดี๋ยวข้าจะนำเอง เจ้าตามข้ามาเลย
        #quest:7
        ->DONE
    +[ยังก่อน]
        งั้นข้าจะรอเจ้าอยู่ตรงนี้นะ พร้อมเมื่อไหร่ก็บอกข้า
        ->DONE