# OMWTS
## On my way to school(학교 가는 길) 🏫
학교 가기 위한 길에서 벌어지는 상황을 게임으로 구성하였습니다.



## ☑️  환경
3D & Vuforia AR 
3D 맵 위에 문구점, 옷 가게, 서점을 들어갈 때 씬이 AR로 전환됩니다.



## 🔘  기능 및 구현 방법

**1. mini map 📍**

<img width="30%" height="20%" alt="스크린샷 2021-03-15 오후 4 39 52" src="https://user-images.githubusercontent.com/50979257/111119437-7b55f780-85ad-11eb-8de0-0fdaa5903330.png">

플레이어의 위치 및 총알의 위치, 상점, 횡단보도, 좀비의 위치, 최종 목적지인 학교의 위치 정보를 파악합니다. 
오브젝트의 layer 를 minimap 으로 설정 한 뒤 맵의 top view 에 minimapl layer 를 위한 카메라를 하나 설정하여 실시간적으로 플레이어의 위치를 파악할 수 있습니다.

**2. player 🙆🏻‍♂️** 

<img width="20%" height="10%" alt="스크린샷 2021-03-15 오후 4 44 28" src="https://user-images.githubusercontent.com/50979257/111119738-d1c33600-85ad-11eb-8174-e14ea2de9354.png">

- 움직임

좌우 버튼을 이용해 y축으로 몸을 회전, 상하 버튼을 통해 앞, 뒤로 이동할 수 있습니다.
모바일 화면 상 각 버튼을 클릭 시 버튼에 해당하는 bool 변수만 true가 되게 하였고 update 함수 내에서 true 인 버튼을 찾아 해당 움직임을 움직이게 하였습니다. 

- 총알 슈팅

맵상의 노란색 총알 획득 후 click 버튼을 통해 총알을 발사할 수 있습니다.

맵 상의 총알은 player 와 총알의 collision 발생 시 총알을 destroy 하고 총알 값을 3 증가 하였으며 click 버튼 클릭 시 총알 프리팹을 생성하였고 가속도 값을 이용해 총알을 발사하였습니다.

**3. camera 📷**

Camera 는 player의 하위 계층에 있으며 player 가 움직일 때마다 같이 움직여 1인칭 시점으로서 역할을 합니다.

**4. zombie 🧟**

좀비는 player 가 사는 마을의 숲 속에 존재합니다. 
좀비는 좌우, 상하로만 왔다 갔다 하며 player 와 충돌 시 player 의 목숨이 하나 감소하게 됩니다. 
Player 는 총알을 이용해 좀비를 쏠 수 있으며 player 가 좀비를 쏘면 좀비의 위치에 준비물이 생성됩니다.
좀비는 Mathf 클래스의 sin 함수를 이용하여 지정한 delta 값만큼 왔다 갔다 할 수 있게 하였습니다.
배열을 사용해 아이템을 저장하였고 좀비가 bullet 과 충돌시 Instantiate 를 사용해 그 좀비의 위치에 아이템이 나타나도록 하였습니다. Static 변수 이므로 retry 시 i 가 3 이상일 경우 0 으로 setting 하는 작업도 추가하였습니다.

**5. Traffic Light 🚦**

Player 가 신호등이 빨간 불일 경우 건너면 player 의 목숨이 1 감소합니다.
신호등의 빨간불, 노란불, 초록불은 random(0,3)함수를 사용해 구현하였으며 Start 함수에 InvokeRepeating 함수를 사용해 5 초마다 불이 변경되도록 하였습니다.

**6. 문구점, 옷 가게, 서점 🏬**

문구점, 옷 가게, 서점은 각각 다른 씬으로 이루어져 있습니다.
문구점, 옷 가게, 서점에 맞는 이미지를 인식시켜야 각 상점에 해당하는 물품이 나오게 됩니다. 
3 가지의 물품이 있으며 이 중에 player 는 item 태그가 설정된 준비물의 물품 클릭 시, 준비물이 1 증가하게 됩니다. 
그 외의 물품을 클릭하였을 경우 물품을 잘못 클릭하였다는 의미로 player 의 목숨이 하나 감소합니다. 
Player 의 클릭 감지하였을 때 플레이어가 클릭한 물품을 RaycastHit 클래스를 사용해 클릭한 물품에 대한 정보 값을 얻어오도록 하였습니다.

**7. 그 외의 UI**

- **당부 말씀 👴**

클릭 시 준비물에 대한 정보를 보여줍니다.
버튼을 한번 더 클릭 시 image의 setActive 를 false 하여 정보를 비활성화시켰습니다.

- **타이머 ⏱**

초기 시간은 5 분으로 설정해 두었습니다. 
time.deltaTime 을 이용해 시간을 카운드 하였고, 문자열의 format 함수를 이용해 00:00 의 형식으로 시간을 보여줍니다.



## 실행 화면 ▶️


<img width="50%" height="40%" alt="스크린샷 2021-03-15 오후 6 06 07" src="https://user-images.githubusercontent.com/50979257/111129282-4059c100-85b9-11eb-9295-a89dfbd35cf1.png">

<img width="50%" height="40%" alt="스크린샷 2021-03-15 오후 6 07 16" src="https://user-images.githubusercontent.com/50979257/111129478-77c86d80-85b9-11eb-9158-19cf5aecadf7.png">

- 할아버지의 당부 말씀 버튼 클릭 시 way 씬으로 이동하여 게임 전반적 규칙에 관해 파악합니다.

<img width="50%" height="40%" alt="스크린샷 2021-03-15 오후 6 08 00" src="https://user-images.githubusercontent.com/50979257/111129486-79923100-85b9-11eb-8f44-d0631c401f87.png">

- 👴클릭시 준비물에 대한 정보를 다시 확인 할 수 있습니다.


<img width="50%" height="40%" alt="스크린샷 2021-03-15 오후 6 08 56" src="https://user-images.githubusercontent.com/50979257/111129969-09d07600-85ba-11eb-9c1a-32a41677715e.png">

- 주인공의 1인칭 시점에서의 화면입니다. 

<img width="50%" height="40%" alt="스크린샷 2021-03-15 오후 6 09 04" src="https://user-images.githubusercontent.com/50979257/111129976-0b9a3980-85ba-11eb-85cf-8def56059b85.png">

- 앞 건물 문구점에 들어가 문구점에 해당하는 이미지 인식시 문구점의 물품들이 나타납니다.
사야할 물품이 아닌 다른 물품 클릭 후 player 의 생명이 하나 줄어 듭니다.
올바른 물품을 클릭하면 가방에 물품이 채워지고 문구점을 나갈 수 있습니다.

<img width="50%" height="40%" alt="스크린샷 2021-03-15 오후 6 09 20" src="https://user-images.githubusercontent.com/50979257/111130009-1523a180-85ba-11eb-8709-376f05f5ffb9.png">

- 신호등이 빨간 색일 경우 건너 player 의 목숨이 하나 줄어들었습니다.

<img  width="50%" height="40%" alt="스크린샷 2021-03-15 오후 6 09 34" src="https://user-images.githubusercontent.com/50979257/111130022-1785fb80-85ba-11eb-94c7-e868c1191560.png">

<img  width="50%" height="40%" alt="스크린샷 2021-03-15 오후 6 09 42" src="https://user-images.githubusercontent.com/50979257/111130031-194fbf00-85ba-11eb-9853-a6bf979cc0fb.png">

- 좀비를 향해 click버튼을 누르면 좀비가 총알에 맞게 되고 좀비가 있던 자리에 아이템이 생성되게 되는데 이 아이템도 획득합니다.


<img  width="50%" height="40%" alt="스크린샷 2021-03-15 오후 6 09 58" src="https://user-images.githubusercontent.com/50979257/111130041-1bb21900-85ba-11eb-904f-6ba78f0476af.png">

<img  width="50%" height="40%" alt="스크린샷 2021-03-15 오후 6 10 05" src="https://user-images.githubusercontent.com/50979257/111130054-1d7bdc80-85ba-11eb-8394-00eb0f87bcb0.png">

- 좀비를 다 죽이고 상점에서 원하는 물건들을 다 사고 학교에 들어가게 되면 게임 성공 메세지가 나오며 게임이 종료됩니다.
준비물을 다 챙기지 못했을 경우 게임 오버 창이 뜨게 되며 retry 버튼을 통해 게임을 다시 진행 할 수 있습니다.

- Retry버튼을 누르면 위의 준비물,목숨,총알,시간 등이 초기화 되며 다시 게임을 실행 할 수 있는 환경이 이루어집니다.











