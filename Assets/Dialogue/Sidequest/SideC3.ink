INCLUDE ../Tutorial/tutorial_globals.ink
->Quest
===Quest===
    {refuseOldMan:->Refuse}
    #speaker:คุณตา
    สวัสดี..ข้าอยากให้เจ้าช่วยอะไรให้หน่อยน่ะไอ้หนุ่ม...
        +[ยอมรับ]
        +[ปฎิเสธ]
            #speaker:คุณตา
            ไม่เป็นไรๆ..เดี๋ยวข้าลองหาความช่วยจากคนอื่นดูแล้วกัน
            เจ้าไปเถอะ..
            ~refuseOldMan = true
            ->DONE
    -ข้าไม่อยากรบกวนเจ้ามาก งั้นเจ้าเลือกมาหนึ่งภารกิจละกัน
    #speaker:quest
    เลือกภารกิจ
        +[บันทึกจากหนังสือ]
            #speaker:คุณตา
            หนังสือนั้นอยู่ในปราสาท มีชั้นหนังสืออยู่แถวนั้น
            มันเป็นหนังของตระกูลข้า
            เจ้าไปเอาแทนข้าที
            #speaker:quest
            \- เควส: บันทึกจากหนังสือ รางวัล: 1500 MP
            #quest:55
            ->DONE
        +[กำจัด Venom]
            #speaker:คุณตา
            พักหลังมานี้ พวก<color=\#FFBD39>Venom</color> เริ่มออกมาอาละวาด
            เจ้าช่วยไปกำจัดให้พวกชาวบ้านที 
            เจ้าเองก็ระวังตัวด้วยล่ะ
            #speaker:quest
            \- เควส: กำจัด <color=\#FFBD39>Venom</color>จำนวน 15 ตัว ที่<color=\#FF7272>Rachne</color> รางวัล: 1000 MP และหนังสือสกิล
            #quest:57
            ->DONE
    == Refuse==
        #speaker:คุณตา
        ว่าอย่างไรล่ะ ไอ้หนุ่ม
        สบายดีหรือเปล่า
        อย่าเอาแต่ทำงานจนไม่ได้กินข้าวกินปลาล่ะ
    ->DONE
->DONE