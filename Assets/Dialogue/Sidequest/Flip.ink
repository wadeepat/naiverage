INCLUDE ../Tutorial/tutorial_globals.ink
->Quest
===Quest===
    {refuseGuard:->Refuse}
    #speaker:ยาม
    สวัสดี...พอดีช่วงนี้ข้าไม่ค่อยสบายเลย
    เหนื่อยมากเลยล่ะ...
    ข้าอยากให้ใครสักคนมาช่วยแบ่งเบาภาระของข้าจังเลย
        +[ให้ช่วยไหม]
        +[ปฎิเสธ]
            #speaker:ยาม
            เชอะ!!
            ~refuseGuard = true
            ->DONE
    -จะดีหรอ...ข้าเห็นเจ้าดูเหนื่่อยจากการที่ไปช่วยคนในเมืองมานะ
        +[ไม่เป็นไรให้ข้าช่วยเถอะ]
    -ถ้าอย่างนั้น...เจ้าสนใจงานไหนล่ะ ค่าตอบแทนดีนะ
    #speaker:quest
    เลือกภารกิจ
        +[รูปแห่งความทรงจำ]
            #speaker:ยาม
            ข้าอยากให้เจ้านำรูปหนึ่งมาให้ข้าที มันติดอยู่ตรงผนังไหนสักที่หนึ่งในหมู่บ้านนี้แหละ..แต่ข้าจำไม่ได้
            และก็อย่าลืมประกอบรู้ให้ข้าด้วยล่ะ
            #speaker:quest
            \- เควส: รูปแห่งความทรงจำ รางวัล: 1500 MP
            #quest:51
            ->DONE
        +[กำจัด Skeleton]
            #speaker:quest
            \- เควส: กำจัด<color=\#FFBD39>Skeleton</color>จำนวน 10 ตัว ที่<color=\#FF7272>Cave</color> รางวัล: 500 MP และสกิลสุดพิเศษ
            #quest:53
            ->DONE
    == Refuse==
        #speaker:ยาม
        มีอะไร!!
        ถ้าไม่มีอะไรก็ไปทำการทำงานของเจ้าซะ
        ออกไป!!
    ->DONE
->DONE