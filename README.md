# AliveMuseum_UNITY
메타버스아카데미3기 3차 융합프로젝트 박물관이 살아있다 Unity(XR) 레포지토리입니다
<br/>

## Assets 폴더 구조
```
Assets
+---01.Level      : 레벨 관련 폴더
| +---Prefabs     : 프리팹 폴더
| +---Scenes      : 씬 폴더 / 실제 서비스 씬과 개인 테스트씬 폴더로 이루어짐
+---02.Art        : TA파트에서 직접 제작한 콘텐츠 폴더
| +---Materials
| +---Models
| +---Textures
| +---UI           : UI 그래픽 폴더
+---03.ThirdParty  : 애셋 스토어 등 외부 애셋 폴더
+---04.Code        : 코드 관련 폴더
| +---Scripts      : C# 코드
| +---Shaders      : 쉐이더 코드
+---05.Animations  : 애니메이션 및 애니메이터 폴더
+---06.Audio       : 오디오 폴더
+---07.Fonts       : 폰트 폴더
```
* `02.Art` 폴더는 TA파트에서 제작한 resources 보관용, `03.Thirdparty` 폴더는 외부에서 가져온 애셋 보관용으로 사용 애셋들을 분리해서 보관하려고 합니다. 그래서 `02.Art` 폴더내부는 TA파트에서 편하게 바꿔서 사용하시면 됩니다.
<br/>

## Branch
`main` : 평소에 Push X / 프로토, 알파, 베타 버전 최종 본 업로드 시에만 사용.
`dev` : 작업 및 합치는 용 branch

* dev_자기이름 branch에선 자유롭게 commit/push 진행
* 에러 없이 완성된 작업 단위로 `dev_자기이름` -> `dev` 브랜치로 merge시켜주면 됩니다
<br/>

## 기타
temp.txt는 업로드용 임시 파일이니 무시해도 됩니다
<br/>
<br/>

## 프로젝트 설정
이 목록에 있는 항목들은 변경 시 팀에 알림 부탁드립니다
<br/>
<br/>

### .gitignore 변경사항
- 기본 Unity gitignore setting
- .idea/workspace.xml
<br/>

### 설치 패키지 목록
- Cinemachine v3.1.1
<br/>

### 씬 목록
- 0.IntroScene			: 인트로 화면 씬
1.StartOutdoorScene	: 게임 초기 시작 야외 씬
2.MuseumScene		: 박물관 내부 메인 씬
<br/>

### Tag 목록
- None
<br/>

### Layer 목록
- None
