INCLUDE ../Tutorial/tutorial_globals.ink
===TheCommandment===
    #speaker:Samuel
    นี้ขอรับ..บัญญัติสวรรค์
    #speaker:Aaron
    “แด่ผู้ปกครอง แด่พลเมือง ข้าพเจ้าที่ผู้ปกครองเมือง <color=\#FF7272>Naver</color> มาอย่างช้านาน ข้าพเจ้าทรงปกปักรักษาคุ้มครองพลเมือง ตามที่บัญญัติสวรรค์แจ้งไว้ทุกประการ และเมื่อมาถึงวันที่จะต้องเปลี่ยนผู้ปกครองใหม่ ข้าพเจ้าก็พร้อมที่จะมอบตำแหน่งและหน้าที่ให้กับคนผู้นั้น โดยคนที่ข้าพเจ้าจะมอบสิทธิในการปกครองให้แก่...”
    #speaker:Abel
    ของใคร???
    #speaker:Aaron
    ชื่อถูกลบออกไป 
    #speaker:Samuel
    จะเป็นไปได้อย่างไร ต่อให้ไม่มีดวงจิตอยู่ในกระดาษนี้ แต่เจตจํานงจะต้องไม่ถูกลบออกไปสิ
    #speaker:Aaron
    หากเป็นอย่างนั้น แล้วใครกันที่จะได้ปกครองเมืองนี้!!!
    #speaker:Abel
    หากไม่มี งั้นเจ้าก็เลือกคนที่เหมาะสมสิ
    #speaker:Samuel
    ทุกอย่างต้องตัดสินจากสารที่ได้รับเท่านั้นขอรับ
    #speaker:Cain 
    แล้วหากเป็นเช่นนี้ เราจะต้องทำอย่างไร
    #speaker:Samuel
    การต่อสู้ขอรับ 
    หากตัดสินด้วยการต่อสู้ก็อาจจะมีโอกาสที่จะได้ คนที่เหมาะสมในการปกครองเมือง
    #speaker:Me
    (ดูเหมือนนี้ไม่ใช่วิธีที่ดีเท่าไหร่นะ)
    #speaker:Aaron
    นี้ไม่ใช่ทางออกที่เหมาะสมนักนะ <color=\#FFD495>Samuel</color>
    #speaker:Samuel
    งั้นวิธีของท่านคืออะไรขอรับ
    หรือท่านจะเป็นผู้เลือก หากท่านเลือกทางผิดท่านคงรู้สินะว่าจะเกิดอะไรขึ้น
    #speaker:Aaron
    ...
    #speaker:Me
    (ไม่ได้การล่ะเราจะต้องเข้าไปช่วยพวกเขา)
    (มีแสงเอฟเฟคออกมา)
    #speaker:The Book
    (ไม่ได้นะ!!!)
    #speaker:Me
    (???)
    (เสียงจากหนังสือหรอ??!!)
    #speaker:The Book
    (เจ้าได้ยินข้าแล้วอย่างนั้นหรอ)
    (การต่อสู่น่ะ มันไม่ใช่ทางออกหรอก)
    (เจ้าเชื่อข้าเถอะ)
    (เจ้าไปกับข้า นี่จะเป็นวิธีเดียวที่จะแก้ไขปัญหาทั้งหมดได้)
    #speaker:Me
    (แล้วเจ้าเป็นใคร)
    #speaker:The Book
    (ตอนนี้ข้าเองก็ไม่รู้ รู้ตัวอีกทีก็เป็นหนังสือติดตามเจ้าไปแล้ว)
    #speaker:Me
    ...
    #speaker:The Book
    (ยังไงก็ตามแต่เจ้าจงเชื่อข้า ไปกับข้าเถิด)
    #speaker:Me
    ...
    #speaker:
    —-เลือกเส้นทางที่ต้องการจะไป—-
        +[เลือกช่วย <color=\#FFD495>Cain</color> เป็นผู้ปกครอง]
            ->ChooseCain
        +[เลือกช่วย <color=\#FFD495>Abel</color> เป็นผู้ปกครอง]
            ->ChooseAbel
        +[เลือกที่จะไปกับหนังสือ]
            ->ChooseTheBook
        +[ไม่เอาสักทาง]
            ->DontChoose
    //ขึ้นแสง 4 ทาง คือ คาอิน อาเบล ไม่เอาสักทาง และหนังสือ
->DONE

===ChooseCain===
    #speaker:Abel
    เจ้ากล้าหันหลังให้กลับข้าอย่างนั้นหรือ!!!
    กล้าดีอย่างไร!!!
    //วาร์ปไปที่ต่อสู่กับอาเบล
    //test
    #action:Ending1
    //#event
->DONE
===ChooseAbel===
    #speaker:Cain 
    เจ้าเลือกน้องข้างั้นเหรอ...
    ช่วยไม่ได้นะ
    ข้าไม่คิดเลยว่าเราจะต้องต่อสู้กันแบบนี้
    เอาล่ะ เรามาตัดสินกัน
    //วาร์ปไปที่ต่อสู่กับคาอิน
     //test
     #action:Ending2
    // ->Ending2
->DONE
===ChooseTheBook===
    #speaker:The Book 
    (ขอบใจที่เชื่อข้า...)
    (เอาล่ะ... การเดินทางนี้เหลืออีกไม่มากแล้ว)
    (ข้าเชื่อว่าเจ้าสามารถทำได้ พยายามเข้าล่ะ)
    #event:BackToPast
->DONE
===DontChoose===
    #speaker:Me
    (ข้าทำมามากพอแล้ว ข้าควรจะหยุดแล้วให้ทุกอย่างเป็นไปตามทางของมัน)
    #speaker:The Book
    (ในเมื่อเจ้าเลือกเส้นทางนี้แล้ว ข้าก็ไม่อาจขัดเจ้าได้ จงไปตามทางของเจ้าเถอะ)
    #action:Ending3 
    //ตัดมาฉากดำ
->DONE
===Ending1===
    #speaker:Cain 
    ขอบคุณที่เข้ามาช่วยเหลือข้า เจ้าคอยช่วยข้าเสมอมา ข้าติดหนี้บุญคุณ
    #speaker:The Book
    (ในเมื่อเจ้าเลือกเส้นทางนี้แล้ว ข้าก็ไม่อาจขัดเจ้าได้ จงไปตามทางของเจ้าเถอะ) 
    //ตัดมาฉากดำ
    #speaker:Ending_1
    (Abel ถูกขับไล่ออกจากเมือง  และก็ไม่ทราบข่าวคราวของเขาอีก)
    (ในส่วนของ <color=\#FFD495>Cain</color> ก็ได้เป็นผู้ปกครองเมือง <color=\#FF7272>Naver</color> แต่เวทย์ปกครองเมืองก็ยังคงเสื่อมลงเรื่อย ๆ จนทำให้ <color=\#FFD495>Cain</color> ประกาศให้ชาวบ้านอพยพจนไม่มีใครอยู่ในเมืองอีกเลย จึงเป็นจุดจบของเมือง Naver)
    (ส่วนข้านั้นก็ยังคงจำอะไรไม่ได้เช่นเคย แม้จะได้รับความช่วยเหลือจาก <color=\#FFD495>Cain</color> แต่ความทรงจำก็ไม่กลับมาอีก)
    (ในเมื่อทำอะไรไม่ได้ ข้าจึงละทิ้งตัวตนเก่าของตนเอง ปล่อยวางทุกสิ่งเพื่อออกไปใช้ชีวิตอยู่ในเมืองใหม่ที่ <color=\#FFD495>Cain</color> ได้สร้างขึ้น)
    (...ใช้ชีวิตอย่างสามัญชนธรรมดา กับโลกเวทย์มนต์ที่แสนจะธรรมดา…)
    #event:BackToMenu
->DONE
===Ending2===
    #speaker:Abel
    ขอบคุณที่เข้ามาช่วยเหลือข้า
    ถึงแม้ว่าเจ้าจะไม่ใช่คนในเมืองนี้ก็ตาม
    #speaker:The Book
    (ในเมื่อเจ้าเลือกเส้นทางนี้แล้ว ข้าก็ไม่อาจขัดเจ้าได้ จงไปตามทางของเจ้าเถอะ)
    // ตัดมาฉากดำ
    #speaker:Ending_2
    (<color=\#FFD495>Cain</color> ถูกขับไล่ออกจากเมือง  และก็ไม่ทราบข่าวคราวของเขาอีก)
    (หลังจากนั้น <color=\#FFD495>Abel</color> ก็ได้เป็นผู้ปกครองเมือง <color=\#FF7272>Naver</color> แต่ก็ได้ไม่นาน เมืองก็แตกพ่ายจากมอนสเตอร์เข้ามารุกรานเนื่องจากเวทย์ปกครองเมืองเสื่อมลงเรื่อย ๆ ผู้คนต่างพาอพยพหนี จึงเป็นจุดจบของเมือง <color=\#FF7272>Naver</color>)
    (ส่วนข้านั้นก็ยังคงจำอะไรไม่ได้เช่นเคย และเลือกที่จะออกจากเมืองนี้ไป)
    (ในเมื่อทำอะไรไม่ได้ ข้าจึงละทิ้งตัวตนเก่าของตนเอง ปล่อยวางทุกสิ่งเพื่อออกไปใช้ชีวิต)
    (...ออกเดินทางเพื่อตามหาตนเอง…)
    #event:BackToMenu
->DONE
===Ending3===
    #speaker:Me
    (ข้าไม่สนใจอะไรอีก ไม่ว่าจะเป็น ชาวเมือง การปกครอง ทหาร และรวมไปตนในอดีตของข้า)
    (ข้าได้ละทิ้งตัวตนเก่าของตนเอง ปล่อยวางทุกสิ่งเพื่อออกไปใช้ชีวิตที่ใดที่หนึ่ง ไม่ต้องถูกใช้งาน ไม่ต้องสนใจใคร อยู่กับตนเอง ได้ออกไปใช้ชีวิตที่ตนเองต้องการ)
    (...เป็นอิสระ...)
    #event:BackToMenu
->DONE

===FoundTheSoul===
    #speaker:Samuel
    นี่ก็คือ...บัญญัติสวรรค์ขอรับ
    #speaker:Sata
    “แด่ผู้ปกครอง แด่พลเมือง ข้าพเจ้าที่ผู้ปกครองเมือง <color=\#FF7272>Naver</color> มาอย่างช้านาน 
    ข้าพเจ้าทรงปกปักรักษาคุ้มครองพลเมือง ตามที่บัญญัติสวรรค์แจ้งไว้ทุกประการ และเมื่อมาถึงวันที่จะต้องเปลี่ยนผู้ปกครองใหม่ ข้าพเจ้าก็พร้อมที่จะมอบตำแหน่งและหน้าที่ให้กับคนผู้นั้น โดยคนที่ข้าพเจ้าจะมอบสิทธิในการปกครองให้แก่...”
    #speaker:Abel
    ของใคร???
    #speaker:Sata
    ชื่อถูกลบออกไปขอรับ
    #speaker:Samuel
    จะเป็นไปได้อย่างไร ต่อให้ไม่มีดวงจิตอยู่ในกระดาษนี้ แต่เจตจํานงจะต้องไม่ถูกลบออกไปสิ
    #speaker:Aaron
    หากเป็นอย่างนั้น แล้วใครกันที่จะได้ปกครองเมืองนี้!!!
    #speaker:The Book
    คนที่จะได้ปกครองเมืองนี้ คือเจ้า “<color=\#FFD495>Sata</color>”...
    #speaker:ทุกคน
    !!!
    #speaker:Abel
    เสียงนี้มัน…ท่านพ่อ!!
    #speaker:Cain 
    ท่านพ่อ…
    #speaker:Me
    (หนังสือนี่ก็คือ กษัตริย์ <color=\#FFD495>Armon</color>)
    #speaker:Sata
    ท…ทำไมถึงเป็นข้าล่ะขอรับ
    #speaker:Armon
    เพราะเรื่องทั้งหมดเกิดจากข้า 
    ข้าเป็นคนทำให้บ้านเมืองเริ่มย้ำแย่ลง
    เพราะคนที่คู่ควรต่อการปกครองเมืองนี้ คือ <color=\#FFD495>Seth</color> พ่อของเจ้าหรือก็คือน้องของข้า
    เพราะข้าต้องการอำนาจ ข้าต้องการที่จะปกครองเมืองนี้ ข้าจึงได้ทำการบังคับเขาให้มอบสิทธิ์การปกครอง หากไม่เป็นไปตามที่ข้าต้องการข้าจะกำจัดเมียกับลูกเขาทิ้งไปซะ เขาจึงยอมจำนน
    #speaker:Aaron
    นี่เจ้า…อย่าบอกนะว่า
    #speaker:Armon
    ข้าสร้างบัญญัติใหม่ให้ <color=\#FFD495>Seth</color> มอบอำนาจมาที่ข้า
    อีกทั้งข้าก็ได้ทำการลบความทรงจำคนในเมือง กับเนรเทศเขาออกจากเมื่อ
    เขายอมออกจากเมืองเพื่อลูกเพื่อเมียของเขา
    ข้ากระทำสิ่งที่เลวร้ายมามากมาย
    จนข้ามีเจ้าทั้งสอง ลูกข้า…
    กว่าที่ข้าจะคิดได้มันก็ทำให้บ้านเมืองแย่ลงไปมากจนเกือบจะไม่สามารถกับมาแก้ไขได้
    แต่ก็ขอบคุณสวรรค์ที่ยังมอบโอกาสให้กับข้าอีกครั้ง
    และนี้จะเป็นโอกาสสุดท้ายที่ข้าจะทำให้ ทุกอย่างกลับมาปกติอย่างเดิม
    ซาตะ…ข้าขอโทษที่ทำให้เจ้าเป็นอย่างนี้
    #speaker:Sata
    …ข้าโกรธที่ท่านทำร้ายพ่อข้า…
    ท่านทำให้ข้าเป็นลูกไม่มีพ่อ
    …แต่ดวงจิตของพ่อข้ากลับมาอยู่ที่ตัวข้า…
    ทำให้ข้าได้รู้ว่า ท่านเพียงแค่ทำไปเพียงเพื่อให้ตนเองได้รับการยอมรับ
    และข้าก็รู้ว่า ท่านก็ทุกข์ไม่ต่างกัน
    ดังนั้น ข้าจึงไม่โทษท่านอีก
    #speaker:Armon
    ...
    ข้าขอบคุณที่เจ้าให้อภัยกับคนอย่างข้า…ขอบคุณ
    #speaker:Samuel
    ถ้าอย่างนั้น บัญญัติสวรรค์การปกครองตกเป็นของ <color=\#FFD495>Sata</color> มีใครจะคัดค้านหรือไม่
    #speaker:Cain 
    ข้าไม่คัดค้าน
    #speaker:Abel
    ถ้ามันไม่ได้ทำมาเพื่อข้า…ข้าก็ไม่ต้องการ
    #speaker:Samuel
    ตอนนี้อำนาจการปกครองตกเป็นของท่าน <color=\#FFD495>Sata</color> แล้วขอรับ จากนี้ไปท่านจะมีนามว่า <color=\#FFD495>King Sata</color>
    #speaker:Me
    (ดูเหมือนเรื่องทุกอย่างจะคลี่คลายแล้วสินะ)
    #speaker:Armon
    (ส่วนเจ้า..เจ้าทำทุกอย่างกลับมาปกติ ข้าจะช่วยฟื้นความทรงจำของเจ้า)
    (แล้วข้าขอบคุณเจ้ามาก ๆ)
    ลาก่อน
    #speaker:Me
    !!!
    #action:TrueEnding
->DONE

===TrueEnding===
    #speaker:TrueEnding
    (หลังจากนั้น กษัตริย์ <color=\#FFD495>Sata</color> ก็ได้ปกครองเมือง <color=\#FF7272>Naver</color>)
    (อีกทั้งบ้านเมืองสงบสุขมากยิ่งขึ้น โดยการปกครองก็รับการช่วยเหลือจาก <color=\#FFD495>Samuel</color>) 
    (ส่วนการรบ <color=\#FFD495>Aaron</color> ก็เป็นคนจัดการ)
    (สองพี่น้อง <color=\#FFD495>Cain</color> และ <color=\#FFD495>Abel</color> ได้ตัดสินใจที่จะแยกย้ายออกกันไปเติบโต) 
    (<color=\#FFD495>Cain</color> ได้ออกเดินทางผจญภัย ส่วน <color=\#FFD495>Abel</color> สร้างเมืองใหม่ และปกครองเมืองนั้นโดยใช้ชื่อว่า เมือง <color=\#FF7272>Armonta</color>)
    (ส่วนข้าได้รับความทรงจำ แล้วได้รู้ว่าข้านั้นเป็นคนในเมืองนักเวทย์แปรธาตุทำให้มีความสามารถทางด้านเวทย์มนต์ แต่บ้านเมืองนั้นได้ล้มสลายไปแล้ว) 
    (ความทรงจำสุดท้ายที่ข้าจำได้ก็คือท่านพ่อ ท่านแม่ที่พูดว่า “จงเลือกเส้นทางของเจ้าแล้วออกเดินทางอย่างสุดกำลัง”)
    (...ตอนนี้ข้าพร้อมที่จะผจญภัย ออกเดินทางอย่างสุดกำลังแล้ว…)
->DONE