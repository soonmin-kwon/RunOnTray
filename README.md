# RunOnTray

CPU 사용량에 따라 달리는 속도가 달라지는 거북이 애니메이션을 Windows 작업 표시줄
알림 영역에서 보여 주는 가벼운 트레이 앱입니다.

[최신 버전 다운로드](https://github.com/soonmin-kwon/RunOnTray/releases/latest)

## 설치

1. Releases 페이지에서 `RunOnTray-win-x64`로 시작하는 최신 ZIP을 다운로드합니다.
2. ZIP 파일을 원하는 폴더에 완전히 압축 해제합니다.
3. `RunOnTray.exe`를 실행합니다.

.NET 런타임이 포함되어 있으므로 별도의 프로그램을 설치할 필요가 없습니다.
`RunOnTray.exe`와 `resources` 폴더는 반드시 같은 폴더에 두세요.

## 주요 기능

- CPU 사용량이 높아지면 더 빠르게 움직이는 트레이 아이콘
- 별도 창 없이 작업 표시줄 알림 영역에서 동작
- 기본 애니메이션 속도 조절
- 트레이 메뉴에서 프로그램 종료

## 사용법

프로그램을 실행하면 작업 표시줄 알림 영역에 거북이 아이콘이 나타납니다. 아이콘이 바로
보이지 않으면 작업 표시줄의 숨겨진 아이콘 메뉴를 확인하세요.

아이콘을 마우스 오른쪽 버튼으로 클릭하면 다음 메뉴를 사용할 수 있습니다.

- `Speed Up`: 기본 애니메이션 속도를 빠르게 조절합니다.
- `Slow Down`: 기본 애니메이션 속도를 느리게 조절합니다.
- `Exit`: 프로그램을 종료합니다.

## 문제 해결

- 아이콘이 표시되지 않으면 ZIP을 완전히 압축 해제했는지 확인하세요.
- `resources` 폴더를 삭제하거나 실행 파일과 분리하면 프로그램이 실행되지 않습니다.
- Windows에서 알 수 없는 게시자 경고가 나타날 수 있습니다. 공식 GitHub Releases에서
  받은 파일인지 확인한 뒤 실행하세요.

## 개발 및 빌드

.NET 8 SDK가 필요합니다.

```powershell
dotnet build RunOnTray.csproj
```

Windows x64용 self-contained 배포본은 다음 명령으로 만들 수 있습니다.

```powershell
dotnet publish RunOnTray.csproj -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true
```

## 지원 환경

- Windows 10/11
- 64비트 Windows PC

아이디어 참고: [RunCat](https://github.com/Kyome22/RunCat_for_windows)
