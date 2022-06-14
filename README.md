# SimpleChat.NET


## Description
> 2022.05. - 2022.06.

- Simple chat for .NET Framework
- C# .NET을 이용한 채팅 프로그램 작성 프로젝트.


## About Project

### Task Order
- 3단계로 작성.

#### Step1

콘솔 앱(.NET Framework)을 이용한 기본적인 Chatting Program 개발.

- server

- client

참조: [https://stackoverflow.com/questions/43431196/c-sharp-tcp-ip-simple-chat-with-multiple-clients]

#### Step2

전반적인 코드 이해 및 정리.

- server

- client

#### Step3

WinForm을 이용한 Client Chatting Program 개발. 

- server

- client

---------------

### Installation and Usage

1. ChatSetup.zip 폴더 다운로드 및 압축 해제.

![1](./doc/install/1.jpg)

2. setup.exe 파일 실행.

![2](./doc/install/2.jpg)

3. 설치 진행.
![3](./doc/install/3.jpg)
![4](./doc/install/4.jpg)
![5](./doc/install/5.jpg)
![6](./doc/install/6.jpg)

4. 바탕화면 SimpleChat 아이콘 생성 확인 및 실행.
![7](./doc/install/7.jpg)

5. Type your name: 칸에 사용자 이름 입력.
![8](./doc/install/8.jpg)
![9](./doc/install/9.jpg)

6. Connect to server 버튼 클릭.
![10](./doc/install/10.jpg)

7. 메시지 입력 후 Send 버튼 클릭.
![11](./doc/install/11.jpg)

8. 채팅 종료시 Disconnect to server 버튼 클릭 후 Close.
![12](./doc/install/12.jpg)



## Singularity

- System.Net.Sockets 소켓 통신 중 TcpClient 클래스를 이용한 소켓 통신.

- Serialize, Deserialize Object Newtonsoft.Json 사용.