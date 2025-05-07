## ✅ 구현 체크리스트 상세 내역

---

### 1️⃣ 캐릭터 이동 및 맵 탐색

- ✅ `PlayerController`는 `BaseController`를 상속받아 `Rigidbody2D.velocity`로 자연스러운 이동 구현
- ✅ 이동 방향에 따라 회전(`flipX`) 및 조준 방향 자동 설정
- ✅ 맵 경계에 `TilemapCollider2D` 또는 경계 오브젝트를 두어 플레이어 이동을 제한

---

### 2️⃣ 맵 설계 및 상호작용 영역

- ✅ `Tilemap`, `Sprite` 기반 오브젝트 배치로 맵 구성
- ✅ `NPC.cs`, `InteractUI.cs`를 통해 상호작용 가능한 오브젝트 배치
- ✅ `Collider2D + OnTriggerEnter2D()`로 특정 영역 진입 시 이벤트 발생

---

### 3️⃣ 미니 게임 실행

- ✅ `MinigameManager.cs`를 통해 미니게임 시작, 종료, 결과 처리 구현
- ✅ 미니게임 시작 전 `Intro UI`를 `UIManager.ShowIntroUI()`로 표시
- ✅ 게임 종료 후 `UIManager.ShowResultUI()`와 `SceneManager.LoadScene()`을 통해 로비로 복귀

---

### 4️⃣ 코인 시스템

- ✅ `StatHandler`와 `ResourceController`로 현재 코인 수 추적
- ✅ `PlayerPrefs`를 이용해 최고 점수(코인) 저장
- ✅ 맵으로 복귀 시 `UIManager`에서 코인 UI 업데이트로 점수 유지 및 출력

---

### 5️⃣ 게임 종료 및 복귀

- ✅ `MinigameManager.GameOver()`와 `GameClear()`로 게임 종료 처리
- ✅ 결과는 `ResultUI.ShowResult()`와 `ShowClear()`를 통해 출력
- ✅ 코인 차감 결과도 UI에 표시 (획득량 계산: `stat.CoinCount - coinBeforeGame`)

---

### 6️⃣ 카메라 추적 기능

- ✅ `CameraFollow.cs` 등에서 `Transform.position`을 따라가며 이동 구현
- ✅ `Clamp()`를 사용해 카메라가 벗어나지 않도록 경계값 설정

---

## 🔥 추가로 구현한 기능

---

### 🎵 사운드 시스템

- ✅ `SoundManager.cs`로 사운드 중앙 관리
- ✅ 배경 음악: `MainScene`, `DungeonScene`마다 BGM 자동 재생
- ✅ 효과음:
    - 코인 획득: `PlayCoin()`
    - 피격: `PlayHit()`
    - 대사 출력: `PlayDialogue()`
    - 걷기: 일정 간격으로 `stepSound` 반복 재생

---

### 💬 대화 시스템

- ✅ `NPC.cs` + `DialogueManager`로 NPC 대화 기능 구현
- ✅ `DialogueUI`에서 NPC 이름, 텍스트, 초상화 출력
- ✅ `F` 키로 대사 진행, `ESC`로 대화 종료 가능

---

### ❤️ UI 시스템 분리

- ✅ `UIManager`는 `HeartUI`, `CoinUI`, `ResultUI`로 기능 분리

---
