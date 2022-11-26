INCLUDE tutorial_globals.ink

VAR name = "Liw"
=== Temp ===
    #speaker:???
    Don't <color=\#40FF6F>judge</color> the book by its cover.
    The answers were <b>already</b> there.
    Open and find it.
    ~readOP = true
->DONE
=== Temp1 ===
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
->DONE
=== Opening ===
    #speaker:Me
    (ที่นี่น่าจะเป็นป่า Rache ตามที่แผนที่บอก)
    (อีกไม่นานคงจะใกล้ถึงเมือง Naver แล้วสินะ)
    (ก่อนอื่นต้องทำยาสมานแผลก่อน น่าจะต้องไปหา <b>"odorata"</b> กับ <b>"aloe"</b> แล้วสิ)
    (แย่หละสิ ตอนนี้ใกล้จะมืดแล้วด้วย คงต้องรีบแล้ว)
    ~readOP = true
->DONE
=== AfterUsePotion ===
    #speaker:Me
    (โอเค...น่าจะดีขึ้นแล้ว ต้องรีบไปแล้ว)
->DONE
=== MetWebster ===
    #speaker:Me
    (ดูเหมือนจะต้องจัดการพวกนั้นก่อนสินะ)
->DONE
=== SataCall ===
    #speaker:??? #sound:singleFootstepInGrass
    เฮ่ เจ้าฮูดแดงนั้นหน่ะ!!
    #speaker:Me 
    ???
    #speaker:???
    นายนั่นแหละ ช่วยมานี่ทีสิ
->SataFirstMet

=== SataFirstMet ===
    {sataAskToJoin: -> SataAskToJoin} 
    #speaker:???
    พอดีข้าได้รับบาดเจ็บจากแมงมุงในป่านี้หนะ..กัดเจ็บเป็นบ้า..
    เจ้าพอจะช่วยข้าหน่อยได้หรือไม่ ข้าต้องการยาที่ใช้สมานแผลสักหน่อย
    ขอบคุณเจ้ามาก ข้าจะไม่ลืมบุญคุณนี้แน่นอน
    ว่าแต่ข้ายังไม่รู้จักชื่อของเจ้าเลย
    เจ้าชื่อว่าอะไรหรอ
        +[บอกชื่อ]
            ->answerYourName
        +[ไม่บอกชื่อ]
            ->answerDontKnow

=== answerDontKnow ===
    #speaker:???
    (เจ้านี้ดูไม่ไว้ใจข้าเลยนะ แต่ก็เอาเถอะ) 
->SataIntroduction

=== answerYourName ===
    #speaker:???
    (ว้าว!! ชื่อเท่ดีนิ เหมาะกับเจ้าดี) 
->SataIntroduction

=== SataIntroduction ===
    #speaker:???
    ส่วนข้า..ข้ามีนามว่า <b>"ซาตะ"</b> ข้าเป็นทหารหน่วยลาดตระเวนเมือง Naver ที่ค่อยดูแลความปลอดภัยของบ้านเมืองนี้ 
    ก่อนหน้านี้ข้าเห็นเจ้าถือแผนที่ที่มายังเมือง Naver ข้าจึงอยากจะถามเจ้าว่าเจ้ามาที่เมืองนี้มีธุระอะไรหรือเปล่า??
        +[บอกเหตุผล]
            ข้าสูญเสียความทรงจำทุกอย่าง สิ่งที่ข้าจำได้มีเพียงคำพูดหนึ่งที่อยู่ในหัวตลอด
            ข้ารู้ตัวอีกทีก็อยู่ที่หมู่บ้านเล็ก ๆ ในหุบเขาหนึ่งที่ห่างจากที่นี่ไกลมาก 
            ไม่มีใครรู้จักข้า และไม่มีใครสามารถช่วยกู้ความทรงจำข้าได้เลย ข้าจึงออกเดินทาง และได้ยินชาวบ้านบอกให้ลองไปขอความช่วยเหลือจากกษัตริย์แห่งสติปัญญา อยู่ที่เมือง Naver) 
            ข้าจึงได้เดินทางมามาที่นี่
    #speaker:ซาตะ
    - ถ้ากษัตริย์ที่เจ้าผู้ถึงคือ กษัตริย์อาร์มอนละก็ ข้าว่า…เขาคงช่วยไม่ได้แล้วล่ะ 
    #speaker:Me
    ทำไมล่ะ
    #speaker:ซาตะ
    คนที่เจ้าตามหาได้เสียชีวิตไปแล้วเมื่อไม่นานมานี้นี่เอง ทำให้ในเมืองเกิดเรื่องวุ่นมากมายเลยล่ะ ไว้ข้าจะเล่าให้ฟัง
    ตอนนี้ใกล้จะมืดแล้วข้าว่ารีบไปจากที่นี่ก่อนดีกว่า
    ข้าจะพาเจ้าไปพักที่เมือง Naver ก่อน แถวนี้อันตรายเกินไป
    !!!
    แย่ละสิ...
    ข้าลืมไปว่าจะต้องหา (ชื่อของ) จาก Webster ประมาณ 5 อัน ข้ายังมาได้ไม่ครบเลย โดนแม่ทัพดุแน่
    เจ้าพอจะช่วยข้าได้หรือไม่ คราวนี้ข้ามีค่าจ้างให้ รวมค่าที่เจ้าได้ช่วยข้าไว้
    เจ้าสนใจไหม
        +[ยอมรับ]
        ~acceptWebsterQ = true
        ข้าจะรอเจ้านะ
        ->DONE
        +[ปฏิเสธ]
        งั้นเหรอ ไม่เป็นไร
        ->DONE
->DONE
        

=== FinishedWebsterQ ===
    #speaker:ซาตะ
    ได้มาแล้วเหรอ ขอบคุณเจ้ามาก ๆ 
    -> GoToNaver
=== GoToNaver ===
    #speaker:ซาตะ
    เจ้าพร้อมจะออกเดินทางหรือยัง?
    +[ไปเลย]
        เดี๋ยวข้าจะนำเอง เจ้าตามข้ามาเลย
        ->DONE
    +[ยังก่อน]
        งันข้าจะรอเจ้าอยู่ตรงนี้นะ พร้อมเมื่อไหร่ก็บอกข้า
        ->DONE
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
