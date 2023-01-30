INCLUDE ../Tutorial/tutorial_globals.ink
===AssembleArmy===
    #speaker:Aaron
    เอาหละพวกทหารทั้งหมดรวมตัว!!!
    ข้าจะให้พวกเจ้าแยกย้ายออกไปตามหาเจ้าชาย
    และพวกเจ้าต้องปลอมตัวให้เป็นชาวบ้านธรรมดา
    หลังจากทราบข่าวแล้วให้ส่งคนมาแจ้งข้าแล้วข้าจะออกไปเจรจากับเข้าอีกที
    ส่วนพวกฝ่ายที่ต้องดูแลชาวบ้าน ก็กลับไปทำงานซะ!!!
    #speaker:All
    รับทราบครับ!!!
    #speaker:Sata
    พวกเรารีบออกเดินทางกันดีกว่า
    #speaker:Me
    นายจะไม่ปลอมตัวหน่อยหรอ
    #speaker:Sata
    ข้าไม่ได้ออกไปกับเจ้าน่ะสิ
    #speaker:Me
    ??? 
    #speaker:Sata
    พอดีข้าเป็นหน่วยลาดตระเวน ทุกคนในเมืองนี้เลยรู้จักข้าไปทั่ว
    คนในหมู่บ้านนั้นก็น่ารู้จักกับข้ากันหมดเลยน่ะสิ ฮ่าๆ
    #speaker:Me
    ...  
    #speaker:Sata
    เอาเถอะ...ที่จริงแม่นางคนที่เราไปช่วยเขาแอบมาบอกที่อยู่ของหมู่บ้านนั้นให้กับข้าแล้ว ข้าเลยอยากให้เจ้าไปเจรจาแทนแม่ทัพน่าจะดีกว่านะ
    #speaker:Me
    ทำไมกัน??
    #speaker:Sata
    ไม่รู้สิ...เพราะข้ารู้สึกคุ้นเคยกับเจ้า และรู้ว่าเจ้าไม่มีทางทำงานพลาดแน่นอน
    เอาเถอะเจ้าลองไปตามแผนที่นี้ดู และเอานี่ไปมอบให้เขาด้วย
    (ได้รับไอเทมเควส: จดหมาย)
    #speaker:quest
    \– เควส: เดินไปยังป่า <color=\#FF7272>Braewood</color> รางวัล:\ -
        +[รับภารกิจ]
            #quest:16
            ->DONE
->DONE
=== TalkWithGuard===
    //ตัวละครเอกอยู่ที่ Braewood (เดินไปคุยกับยามหน้าประตู)
    #speaker:ยามหน้าประตู
    เจ้าเป็นใคร!!
        +[ผมเป็นคนในหมู่บ้านครับ]
            ..ง..งั้นหรอ งั้นก็เข้ามา
        +[ผมพึ่งอพยพออกมาจากเมือง Naver ครับ]
            เข้ามาได้
    #speaker:Me
    -(ง่ายๆ อย่างงี้เลยหรอ)
    (เอาล่ะก่อนอื่นต้องตามหาเจ้าชายก่อน)
    (ก่อนอื่นลองไปถามคนที่อยู่แถวนี้ดูก่อน)
    #speaker:quest
    \- เควส: เข้าไปคุยกับชาวบ้านเพื่อตามหาเจ้าชาย รางวัล: \-
        +[รับภารกิจ]
            #quest:17
            ->DONE
->DONE
===TalkToVillager0===
    #speaker:Me
    เจ้าพอรู้บ้างไหมว่าเจ้าชาย <color=\#FFD495>Cain</color> อยู่ไหน
    #speaker:ชาวบ้าน
    อะไรนะเจ้าชาย <color=\#FFD495>Cain</color> หรอ
    ข้าไม่รู้หรอก ข้าไม่ได้อยู่กับเขานี้ เจ้าไปถามคนอื่นเถอะ
    อีกอย่างเขาไม่ต้องการให้ใครเรียกเขาว่าเจ้าชายอีกแล้วนะ ระวังคำพูดด้วยล่ะ
->DONE
===TalkToVillager1===
    #speaker:Me
    เจ้าพอรู้หรือไม่ว่า <color=\#FFD495>Cain</color> อยู่ไหน
    #speaker:ชาวบ้าน
    ถ้า <color=\#FFD495>Cain</color> ละก็ข้ายังไม่เห็นนะ คนที่รู้น่าจะเป็นยามหน้าประตู
    #event:enableGuardTalk
    ยามนั่นน่าจะรู้ว่าเขาอยู่ไหนแน่นอน
->DONE
===AskGuardAboutCain===
    #speaker:Me
    <color=\#FFD495>Cain</color> อยู่ไหน
    #speaker:ยามหน้าประตู
    เจ้าอีกแล้วหรอ!!! <color=\#FFD495>Cain</color> เขาเข้าไปในถ้ำแล้ว กว่าจะออกมาก็น่าจะนานหน่อยนะ
    #speaker:Me
    (งั้นเราต้องรีบไปหาเขาแล้ว)
    #speaker:ยามหน้าประตู
    ถ้าเจ้าจะไปก็ระวังตัวด้วยละกัน ในถ้ำมันอันตราย
    #speaker:quest #event:FindCain
    \- เควส: ตามหาเจ้าชายคาอินในถ้ำ รางวัล: \-
        +[รับภารกิจ]
            #quest:19
            ->DONE
->DONE
    //(เข้าไปในถ้ำเจอเจ้าชายยืนอยู่ตรงทางเข้าถ้ำ)
===FirstMetCain===
    #speaker:Cain
    แฮ่กๆ...ใครกัน
        +[{name}]
        งั้นหรอ...มาก็ดีเลยช่วยข้าที...
        +[ชายชุดแดงยังไงล่ะ]
        งั้นหรอ...มาก็ดีเลยช่วยข้าที...
    - +[ให้ช่วยอะไร]
    -เจ้าช่วยข้ากำจัด <color=\#FFBD39>Skeleton</color> ให้ข้าทีสิ หากไม่กำจัดมันแล้วละก็มันจะออกจากถ้ำแล้วมารุกรานหมู่บ้านนี้ได้
    หากเจ้ากำจัดมอนเสร็จแล้วมาแจ้งข้า ตอนนี้ข้าไม่มีแรงเหลือแล้ว ข้าขอนั่งพักอยู่ตรงนี้สักพัก 
    #speaker:quest
    \- เควส: กำจัดศัตรูไม่ให้รุกรานหมู่บ้าน เมื่อทำเสร็จมารับรางวัลที่ <color=\#FFD495>Cain</color> รางวัล: 500 MP
        +[รับภารกิจ]
            #quest:20
            ->DONE
->DONE

===HelpCainComplete===
    #speaker:Cain
    มาแล้วหรอ...ขอบคุณเจ้ามาก ๆ ว่าแต่ก่อนหน้านั้นเจ้ามีอะไรรึเปล่าถึงมาหาข้าถึงที่นี่
    +[ข้ามีบางสิ่งมามอบให้เจ้า (มอบจดหมาย)]
    -(<color=\#FFD495>Cain</color> อ่านจดหมาย)
    พ…พ่อของข้า ตายแล้วอย่างนั้นรึ!!! 
    เป็นไปได้อย่างไรกัน...ในวันนั้น ข้าพึ่งได้พูดคุยกับเข้าอยู่เลย 
    #speaker:Me
    (ถึงแม้ว่า <color=\#FFD495>Cain</color> มีสีหน้าที่ดูปกติ แต่ในแววตานั้นแฝงความเศร้าสร้อยอยู่)
    #speaker:Cain
    ...
    ข้าว่าตอนนี้พวกเราออกจากถ้ำกันก่อนดีกว่า ถ้ายิ่งมืดยิ่งอันตราย พวกสัตว์ร้ายในถ้ำจะยิ่งดุร้ายขึ้น
    #speaker:quest
    \- เควส:ออกจากถ้ำไปคุยกับ <color=\#FFD495>Cain</color> รางวัล: \-
        +[รับภารกิจ]
            #quest:22
            ->DONE 
->DONE
===PrinceAndVillagers===
    #speaker:ชาวบ้านชาย
    ถ้าไม่ใช่ท่านก็ไม่มีใครช่วยเขาได้แล้ว!!!
    และถ้าหากไม่รีบแล้วล่ะก็ เขาอาจจะตายได้เลยนะครับ
    +[เกิดอะไรขึ้น]
    #speaker:Cain
    -เพื่อนของเขายังไม่ออกมาตั้งแต่ตอนเช้า เขาเข้าไปในที่ถ้ำนั่นพร้อมกันกับพวกข้า 
    ถ้าหากตอนนี้ยังหาเขาไม่เจอแล้วล่ะก็ คงอาจจะตายไปแล้ว หรือไม่ก็บาดเจ็บหนักอยู่ในถ้าก็เป็นได้
    ตอนนี้เราคงต้องพักก่อนรอเวลาจนกว่าจะเช้า
    #speaker:ชาวบ้านชาย
    ข้าขอร้องท่านล่ะครับ!!! อย่างน้อยตอนนี้ก็มีโอกาสที่เขาจะรอดมากกว่าที่จะรอเวลาจนถึงเช้านะครับ
    #speaker:Cain
    ...
    #speaker:ชาวบ้านชาย
    ข้าเชื่อในตัวท่าน <color=\#FFD495>Cain</color> ว่าท่านจะช่วยเพื่อนของข้าได้
    #speaker:Me
    (ตอนนี้คาอินกำลังบาดเจ็บอยู่ แล้วเขาจะออกไปช่วยไหวได้อย่างไร)
    #speaker:Cain
    ข้าเข้าใจแล้ว เดี๋ยวข้าจะเข้าไปตามหาให้เอง
    +[ข้าไปด้วย]
        (<color=\#FFD495>Cain</color> พยักหน้า)
    #speaker:ชาวบ้านชาย #event:FriendLeave
    -ขอบคุณพวกท่านมาก ๆ ที่ช่วยพาเพื่อนข้ากลับมา ยังไงก็ฝากพวกท่านด้วย
    #speaker:Me
    <color=\#FFD495>Cain</color> ...ตอนนี้เจ้าเป็นอย่างไรบ้าง
    #speaker:Cain
    ถ้าร่างกายข้าล่ะก็พอไหวอยู่ แต่ข้าแค่เหนื่อยเท่านั้นเอง
    บางครั้ง...ข้าเองก็เหนื่อยที่ต้องคอยแบกรับกับหน้าที่หรือทุกสิ่งทุกอย่างที่ข้าทำ
    ทุกคนต่างพากันคาดหวังในตัวข้า มากกว่าที่ข้าคาดหวังกับตัวเองเสียอีก
    ไม่เคยมีใครถามข้าแม้แต่ครั้งเดียวว่าไหวหรือไม่
    มีแต่คำร้องขอในสิ่งที่ตนต้องการ
    ...แล้วข้าเล่า ข้ามีสิทธิที่จะร้องขออะไรบ้างได้หรือไม่
    ...ข้าเองก็กลัวตาย ไม่ต่างจากพวกเขานักหรอก
    #speaker:Me
    ...
    (ดูแล้วเขาคงแบกรับอะไรไว้มากพอดูเลย)
    #speaker:Cain
    เอาเถอะเราคงต้องรีบแล้ว
    เดี๋ยวเจ้ากับข้าคงต้องแยกกันไปออกตามหาภายในถ้ำเพื่อไม่ให้เสียเวลา
    #speaker:quest
    \- เควส: ตามหาชายหนุ่มที่หายไปในถ้ำ รางวัล: \-
        +[รับภารกิจ]
            #quest:23
            ->DONE
->DONE
===ManInCave===
    #speaker:ชาวบ้านชาย #event:FoundTheMan
    !!!!
    ท…ท่าน!!! ช…ช่วยข้าด้วย!!!!
    #speaker:Me
    เป็นอย่างไรบ้าง
    #speaker:ชาวบ้านชาย
    ตอนนี้ข้าถูกพันธนาการโดยยักษ์ <color=\#FFBD39>Troll</color> นั่น เจ้าช่วยข้าที!!! ตอนนี้ร่างกายข้าขยับอะไรไม่ได้เลย
    #speaker:Me
    แล้วตอนนี้ยักษ์นั่น มันอยู่ไหนล่ะ
    #speaker:ชาวบ้านชาย
    จ…เจ้ายักษ์นั้นอยู่ด้านในนั้น
    เจ้าช่วยจัดการเจ้ายักษ์ให้ข้าที ไม่อย่างนั้นข้าคงตายแน่ๆ
    #speaker:quest
    \- เควส: กำจัด <color=\#FFBD39>Troll</color> รางวัล: \-
        +[รับภารกิจ]
            #quest:24
            ->DONE
->DONE
===SaveTheManLife===
    #speaker:Cain
    ตอนนี้เจ้าเป็นอย่างไรบ้าง
    #speaker:ชาวบ้านชาย
    ดูเหมือนข้าจะเริ่มขยับร่างกายได้บ้างแล้ว ยังไงก็ขอบคุณพวกท่านมาก ๆ เลยนะ แล้วเพื่อนข้าเป็นอย่างไรบ้าง
    #speaker:Cain
    พวกเขาปลอดภัยดี ออกมาก่อนเจ้าอีก
    #speaker:ชาวบ้านชาย
    ฮ่าๆ ...นั่นสินะ
    #speaker:Cain
    เดี๋ยวข้าพาเขาออกไปเอง เดี๋ยวเจอกันที่หมู่บ้านนะ
    #speaker:quest
    \- เควส: ไปคุยกับ <color=\#FFD495>Cain</color> รางวัล: 1000 MP  
        +[รับภารกิจ]
            #quest:26
            ->DONE
->DONE

===BackToFriend===
    {cainAskToGo:-> CainAskToGoToNaver}
    #speaker:ชาวบ้านชาย(ที่บาดเจ็บ)
    ข้าอยากจะขอบคุณพวกท่านอีกครั้ง หากไม่ได้พวกท่านช่วยไว้ ข้าคงตายอยู่ในถ้ำแน่นอน
    #speaker:ชาวบ้านชาย
    ข้าก็อยากจะขอบคุณพวกท่านเช่นกัน เพราะพวกท่านให้การช่วยเหลือทำให้เพื่อนของข้าไม่ตาย
    #speaker:Cain
    ไม่เป็นไรหรอก อีกอย่างเจ้านั่นต่างหากที่พวกเจ้าต้องขอบคุณ เจ้านั่นเป็นคนกำจัด <color=\#FFBD39>Troll</color> นั้นด้วยตัวเอง ข้าเพียงแต่พาเพื่อนเจ้าออกมา
    #speaker:ชาวบ้านชาย
    ดูเหมือนเพื่อนข้ายังจะต้องการพักฟื้นอีกสักหน่อย ยังไงพวกข้าขอตัวก่อน
    (ชายทั้งสองเดินออกมา)
    #speaker:Cain
    ข้าตัดสินใจได้แล้วล่ะ
        +[อะไรหรอ]
    -ข้าจะกลับไปเมือง <color=\#FF7272>Naver</color> อีกครั้ง
    #speaker:Me
    !!!
    ~cainAskToGo = true
->CainAskToGoToNaver
=== CainAskToGoToNaver ===
    #speaker:Cain
    เจ้าจะไปพร้อมกับข้าเลยไหม
        +[ไปเลย]
        #quest:27
        ->DONE
        +[ยังก่อน]
        เดี๋ยวข้าจะรอเจ้าอยู่ที่นี่ เจ้าไปทำธุระของเจ้าก่อนเถอะ
        ->DONE
->DONE
===AssembleArmyAgain===
    #speaker:Aaron
    เอาหละพวกทหารทั้งหมดรวมตัว!!!
    ข้าจะให้พวกเจ้าแยกย้ายออกไปตามหาเจ้าชาย
    และพวกเจ้าต้องปลอมตัวให้เป็นชาวบ้านธรรมดา
    หลังจากทราบข่าวแล้วให้ส่งคนมาแจ้งข้าแล้วข้าจะออกไปเจรจากับเข้าอีกที
    ส่วนพวกฝ่ายที่ต้องดูแลชาวบ้าน ก็กลับไปทำงานซะ!!!
    #speaker:All
    รับทราบครับ!!!
    #speaker:Sata
    พวกเรารีบออกเดินทางกันดีกว่า
    #speaker:Me
    ….
    #speaker:Sata
    ข้าไม่ได้ออกไปด้วยนะ แต่ว่าเอาแผน และจดหมายนี่ไปมอบให้เขาด้วยล่ะ
    (ได้รับไอเทมเควส: จดหมาย)
    แต่น่าแปลกจัง?
    #speaker:Me
    ทำไมรึ?
    #speaker:Sata
    ไม่ว่าข้าจะทำอะไร เจ้าก็ดูไม่แปลกใจเลย 
    จะว่าไปเจ้าก็ดูคุ้นหน้าคุ้นตาอยู่นะ
    #speaker:Me
    …
    #speaker:Sata
    หรือว่าเจ้าเคยปลอมตัวเข้ามาในเมืองนี่!!
    #speaker:Me
    (ไปเรื่อยละคน ๆ นี้)
    #speaker:Sata
    ฮ่า ๆ ข้าล้อเล่น
    เอาล่ะ..เดินทางปลอดภัย!!
    #speaker:Me
    (แล้วข้าจะมาทำภารกิจซ้ำทำไมอีกเนี่ย)
    #speaker:The Book
    (เอาเถอะน่า..รอไปก่อน ข้ารอให้ของสิ่งนี้มันบอกข้า)
    #speaker:Me
    (ของอะไร)
    #speaker:The Book
    (เดี๋ยวก็รู้)
    #speaker:Me
    (คิดถูกรึเปล่าเนี่ย..ที่ตามเจ้านี่มา)
    #speaker:The Book
    (เจ้าคิดถูกที่สุดแล้ว เอาเถอะอย่าให้เสียเวลา)
    #speaker:quest
    \–เควส: ไปหา Cain ในถ้ำ รางวัล: \-
        +[รับภารกิจ]
            #quest:
            ->DONE
->DONE
===FirstMetCainAgain===
    //(เข้าไปในถ้าเจอเจ้าชายยืนอยู่ตรงทางเข้าถ้า)
    #speaker:Cain
    แฮ่กๆ...ใครกัน
        +[{name}]
        งั้นหรอ...มาก็ดีเลยช่วยข้าที...
        +[ชายชุดแดงยังไงล่ะ]
        งั้นหรอ...มาก็ดีเลยช่วยข้าที...
    - +[ให้ช่วยอะไร]
    -เจ้าช่วยข้ากำจัด <color=\#FFBD39>Skeleton</color> ให้ข้าทีสิ หากไม่กำจัดมันแล้วละก็มันจะออกจากถ้ำแล้วมารุกรานหมู่บ้านนี้ได้
    หากเจ้ากำจัดมอนเสร็จแล้วมาแจ้งข้า ตอนนี้ข้าไม่มีแรงเหลือแล้ว ข้าขอนั่งพักอยู่ตรงนี้สักพัก 
    #speaker:quest
    \- เควส: กำจัดศัตรูไม่ให้รุกรานหมู่บ้าน เมื่อทำเสร็จมารับรางวัลที่ <color=\#FFD495>Cain</color> รางวัล: 500 MP
        +[รับภารกิจ]
            #quest:20
            ->DONE
->DONE
===HelpCainCompleteAgain===
    #speaker:Cain
    มาแล้วหรอ...ขอบคุณเจ้ามาก ๆ ว่าแต่ก่อนหน้านั้นเจ้ามีอะไรรึเปล่าถึงมาหาข้าถึงที่นี่
    +[ข้ามีบางสิ่งมามอบให้เจ้า (มอบจดหมาย)]
    -(<color=\#FFD495>Cain</color> อ่านจดหมาย)
    พ…พ่อของข้า ตายแล้วอย่างนั้นรึ!!! 
    เป็นไปได้อย่างไรกัน...ในวันนั้น ข้าพึ่งได้พูดคุยกับเข้าอยู่เลย 
    #speaker:Me
    (หน้าตาเจ้านี่ก็ยังดูเศร้าเหมือนเดิมเลย)
    #speaker:Cain
    ...
    ข้าว่าตอนนี้พวกเราออกจากถ้ำกันก่อนดีกว่า ถ้ายิ่งมืดยิ่งอันตราย พวกสัตว์ร้ายในถ้ำจะยิ่งดุร้ายขึ้น
    #speaker:Me
    ด…เดี๋ยวก่อน!!
    #speaker:Cain
    ???
    #speaker:Me
    ข้าคิดว่ามีคนติดอยู่ที่นี่ 
    #speaker:Cain
    เจ้ารู้ได้อย่างไร
        +[เอาเป็นว่าข้ารู้ก็แล้วกัน]
            งั้นเจ้าก็พาข้าไปสิ
        +[....]
            งั้นแล้วแต่เจ้าละกัน
    #speaker:quest
    -\- เควส: ตามหาชายหนุ่มที่หายไปในถ้ำ รางวัล: \-
        +[รับภารกิจ]
            #quest:
            ->DONE
->DONE
===ManInCaveAgain===
    #speaker:ชาวบ้านชาย
    !!!!
    ท…ท่าน!!! ช…ช่วยข้าด้วย!!!!
    #speaker:Me
    เป็นอย่างไรบ้าง
    #speaker:ชาวบ้านชาย
    ตอนนี้ข้าถูกพันธนาการโดยยักษ์ <color=\#FFBD39>Troll</color> นั่น เจ้าช่วยข้าที!!! ตอนนี้ร่างกายข้าขยับอะไรไม่ได้เลย
    #speaker:Me
    แล้วตอนนี้ยักษ์นั่น มันอยู่ไหนล่ะ
    #speaker:ชาวบ้านชาย
    จ…เจ้ายักษ์นั้นอยู่ด้านในนั้น
    เจ้าช่วยจัดการเจ้ายักษ์ให้ข้าที ไม่อย่างนั้นข้าคงตายแน่ๆ
    #speaker:quest
    \- เควส: กำจัด <color=\#FFBD39>Troll</color> รางวัล: \-
        +[รับภารกิจ]
            #quest:
            ->DONE
->DONE
===SaveTheManLifeAgain===
    #speaker:Cain
    ตอนนี้เจ้าเป็นอย่างไรบ้าง
    #speaker:ชาวบ้านชาย
    ดูเหมือนข้าจะเริ่มขยับร่างกายได้บ้างแล้ว ยังไงก็ขอบคุณพวกท่านมาก ๆ เลยนะ แล้วเพื่อนข้าเป็นอย่างไรบ้าง
    #speaker:Me
    พวกเขาปลอดภัยดี ออกมาก่อนเจ้าอีก
    #speaker:Cain
    ...
    #speaker:ชาวบ้านชาย
    ฮ่าๆ...นั่นสินะ
    #speaker:Cain
    เดี๋ยวข้าพาเขาออกไปเอง เดี๋ยวเจอกันที่หมู่บ้านนะ
    #speaker:quest
    \- เควส: ไปคุยกับ <color=\#FFD495>Cain</color> รางวัล: 1000 MP  
        +[รับภารกิจ]
            #quest:
            ->DONE
    #speaker:ตัวละครชาย(ที่บาดเจ็บ)
    ข้าอยากจะขอบคุณพวกท่านอีกครั้ง หากไม่ได้พวกท่านช่วยไว้ ข้าคงตายอยู่ในถ้ำแน่นอน
    #speaker:ตัวละครชาย(เพื่อนมัน)
    ข้าขอบคุณพวกท่านมาก ๆ เมื่อกี้ข้ากำลังจะมาหาท่านให้เข้าไปช่วยเพื่อนข้าอยู่พอดีเลย
    #speaker:Cain
    เจ้าไม่ต้องขอบคุณข้าหรอก เจ้านั้นเป็นคนกำจัด Troll นั้นด้วยตัวเอง ข้าเพียงแต่พาเพื่อนเจ้าออกมาเท่านั้น 
    #speaker:ตัวละครชาย(เพื่อนมัน)
    ดูเหมือนเพื่อนข้ายังจะต้องการพักฟื้นอีกสักหน่อย ยังไงพวกข้าขอตัวก่อน
    (ชายทั้งสองเดินออกมา)
    #speaker:Cain
    ข้ามีคำถาม
        +[อะไรหรอ]
    ทำไมเจ้าถึงรู้เหตุการณ์ที่เจ้านั้นหายตัว และยังรู้ว่าอยู่ที่ไหนอีก
    #speaker:Me
    …ข…ข้าแค่ได้ยินมาในหมู่บ้านน่ะ
    (ข้าควรจะให้เขากลับไปดีไหมนะ)
    #speaker:The book 
    (ดี!!)
    #speaker:Me
    ยังไงก็เถอะ ข้าต้องการให้เจ้ากลับไปกับข้า 
    #speaker:Cain
    หน้าตาเจ้าดูเหมือนรู้อยู่แล้วว่าจะต้องไปเลยนะ
    แต่ก็แน่นอนข้าจะกลับไป
    เจ้าจะไปพร้อมกับข้าเลยไหม
        +[ไปเลย]
        (เดินออกไปเลย)
    -[ยังก่อน]
        เดี๋ยวข้าจะรอเจ้าอยู่ที่นี้ เจ้าไปทำธุระของเจ้าก่อนเถอะ
->DONE

===BackToFriendAgain===
    {cainAskToGoAgain:-> CainAskToGoToNaverAgain}
    #speaker:ชาวบ้านชาย(ที่บาดเจ็บ)
    ข้าอยากจะขอบคุณพวกท่านอีกครั้ง หากไม่ได้พวกท่านช่วยไว้ ข้าคงตายอยู่ในถ้ำแน่นอน
    #speaker:ชาวบ้านชาย
    ข้าก็อยากจะขอบคุณพวกท่านเช่นกัน เพราะพวกท่านให้การช่วยเหลือทำให้เพื่อนของข้าไม่ตาย
    #speaker:Cain
    ไม่เป็นไรหรอก อีกอย่างเจ้านั่นต่างหากที่พวกเจ้าต้องขอบคุณ เจ้านั่นเป็นคนกำจัด <color=\#FFBD39>Troll</color> นั้นด้วยตัวเอง ข้าเพียงแต่พาเพื่อนเจ้าออกมา
    #speaker:ชาวบ้านชาย
    ดูเหมือนเพื่อนข้ายังจะต้องการพักฟื้นอีกสักหน่อย ยังไงพวกข้าขอตัวก่อน
    (ชายทั้งสองเดินออกมา)
    #speaker:Cain
    ข้ามีคำถาม
        +[อะไรหรอ]
    -ทำไมเจ้าถึงรู้เหตุการณ์ที่เจ้านั้นหายตัว และยังรู้ว่าอยู่ที่ไหนอีก
    #speaker:Me
    ...ข...ข้าแค่ได้ยินมาในหมู่บ้านน่ะ
    (ข้าควรจะให้เขากลับไปดีไหมนะ)
    #speaker:The book 
    (ดี!!)
    #speaker:Me
    ยังไงก็เถอะ ข้าต้องการให้เจ้ากลับไปกับข้า 
    #speaker:Cain
    หน้าตาเจ้าดูเหมือนรู้อยู่แล้วว่าจะต้องไปเลยนะ
    แต่ก็แน่นอนข้าจะกลับไป
    ~cainAskToGoAgain = true
->CainAskToGoToNaverAgain
=== CainAskToGoToNaverAgain ===
    #speaker:Cain
    เจ้าจะไปพร้อมกับข้าเลยไหม
        +[ไปเลย]
        #quest:
        ->DONE
        +[ยังก่อน]
        เดี๋ยวข้าจะรอเจ้าอยู่ที่นี่ เจ้าไปทำธุระของเจ้าก่อนเถอะ
        ->DONE

