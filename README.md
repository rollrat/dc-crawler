# dc-crawler

DC-Crawler는 방대양한 양의 특정 자료를 수집, 검색하기 위한 목적으로 제작되고 있는 프로그램이며, 오픈소스 프로젝트이다. 그 성격은 robots.txt를 따르며, 자료수집 이외의 다른 기능은 추가하지 아니한다.

# 프로그램 소개
이 프로그램은 자료수집은 쉽게 진행하기 위하여 그 기능들을 종합시킨 도구이다. 크게 일반 보기, 특수 검색, 랭킹, 데이터 수집 기능을 지원한다. 이 기능들은 모두 단순한 데이터 수집 기능을 기반으로 제작되었음을 알린다.

### 주요창
![alt tag](https://github.com/rollrat/dc-crawler/blob/master/DC%20Crawler/1.png)

프로그램 실행시 처음으로 보게될 창이다. 이 창은 설정된 갤러리에 해당하는 게시글을 보여준다. 먼저 왼쪽 상단의 `id`는 갤러리의 이름을 입력한다(검색 기능을 지원한다.) `page`부분은 불러올 페이지를 설정한다. 아마 쓸데는 없을 것 같다. `author`부분은 특정 작성자의 글을 불러온다. `Load`버튼으로 설정된 값을 실행한다.

노란색으로 채워진 게시글은 작성자가 고정닉인 경우이고, 회색과 흰색은 각각 비고정닉, 유동닉인 경우이다. 이는 이하 창들에도 모두 적용된다.

#### 열람창
![alt tag](https://github.com/rollrat/dc-crawler/blob/master/DC%20Crawler/5.png)

각 게시물 항목에서 오른쪽 마우스 버튼을 누르면 해당하는 게시물의 댓글과 내용을 열람할 수 있다.

이 창에선 몇 가지 단축키로 다른 기능을 접근할 수 있다.

### 검색창 (F2 키)
![alt tag](https://github.com/rollrat/dc-crawler/blob/master/DC%20Crawler/2.png)

특정사용자의 닉네임이나 IP주소 두 자리로 해당하는 모든 글과 댓글을 가져온다. 오른쪽 상단의 체크박스 버튼으로 댓글만이나 게시글만 가져올 수 있도록 설정할 수 있다. 오른쪽 아래 `Start`버튼으로 찾기를 시작한다. 단, 이 버튼 바로옆 `Author`, `IP`중 하나를 체크하고 진행한다.

검색하는 중 왼쪽 하단의 `Save`버튼으로 가져온 정보를 저장할 수 있다. 가장 최근 업데이트에선 모든 항목마다 Author을 표시할 수 있게 만들었다.

`Activity Time` 버튼은 시간대별 댓글, 게시글 수를 조사한 결과를 보여준다.

### 종합 랭킹 (F4, F5, F6 키)
![alt tag](https://github.com/rollrat/dc-crawler/blob/master/DC%20Crawler/3.png)

특정 갤러리에서 특정 페이지 내에 존재하는 사용자들의 게시글, 댓글 개수를 순위를 매겨 표현한다. 이 순위는 `게시글 수 * 2.5 + 댓글 수 * 1.5`식을 따른 종합 랭킹 점수(Score)를 기준으로한 순위이다.

#### 출력창
![alt tag](https://github.com/rollrat/dc-crawler/blob/master/DC%20Crawler/4.png)

`Export`는 랭킹을 특정 설정값에 따라 파일로 출력하는 도구이다. 설명은 생략한다.

### DC-Data (F7 키)
![alt tag](https://github.com/rollrat/dc-crawler/blob/master/DC%20Crawler/6.png)

이 창은 크롤러의 본체라 할 수 있는 크롤링 전용 창이다. 해당하는 갤러리의 `id`와 페이지를 설정한 후 `Start`버튼을 누르면 모든 댓글에 관한 정보, 게시글 정보를 다운로드하여 `...\년도\월\일\게시글번호`폴더의 형태로 저장한다. 이 기능은 한창 개발 중에 있고, 아직 수집 기능만 지원한다.


# 개발 정보
## 얼개
Html의 복잡한 그 특성에 맞춰 정규표현식을 이용하여 작성되었다. 


### frmMain.vb
이 파일엔 모든 하위 파일에 사용되는 여러 함수와 변수가 포함된다. 

##### 갤러리 목록 가져오기
`DCGallList`는  `gall\.dcinside\.com\/board\/lists\/\?id\=(\w+)\""[\s\S]*?;""\s?\>(.*?)\<`의 표현식을 가진다. `http://wstatic.dcinside.com/gallery/gallindex_iframe_new_gallery.html`주소에서 모든 갤러리의 리스트를 가져오는 `ListingGallery`함수를 이용하여 `GallList`인 딕셔너리 변수에 `갤러리 이름,갤러리 정보`형태로 저장한다. 갤러리 정보는 `identification`와 `name`이 있는데, 각각 갤러리 `id`와 `갤러리 이름`을 나타낸다.

##### 게시판 목록 가져오기
`DCMap`는 `notice"" >(\d+)<[\s\S]*?middle;"">(.*?)</a></td>[\s\S]*?user_id='(.*?)' user_name.*?<span title='(.*?)'[\s\S]*?date"" title=""([\s\S]*?)"">.*?<[\s\S]*?hits"">(\d+)<[\s\S]*?hits"">(\d+)<`의 표현식을 가진다. `GetDCMapFromUrlAnsyc`함수는 `http://gall.dcinside.com/board/lists/?id={loadedId}&page={i}`인 주소에서 html파일을 다운로드해 `webClient_DownloadStringCompleted`에서 분석되게 되는데, 여기서 `DCMapStructure`이 이용된다. 이 구조체엔 `게시글 식별번호, 제목, 댓글 수, 작성자, 날짜, 조회수, 추천수, 작성자 level, user id`가 각각 순서대로 저장된다. 여기서 `작성자 level`은 구역 전체에서 판단하게 되는데, `<img src='http://wstatic.dcinside.com/gallery/skin/gallog/g_default.gif`가 포함된 경우엔 비고정닉으로, `<img src='http://wstatic.dcinside.com/gallery/skin/gallog/g_fix.gif`가 포함된 경우엔 고정닉으로 판단하고, 둘 다 아닐 경우 유동닉으로 가정한다. Line 276에서 사용되는 `Substring`함수는 날짜단위를 분단위로 끊기 위해 사용된다. 제목부분 분기점에선 제목에 댓글 개수가 포함되어 있는지의 여부를 판단하는 분기가 있다. `</a>`가 제목에 포함된다면 댓글이 존재하며, 그 댓글은 `<em>[`와 `]`사이에 존재한다. 글 제목엔 HTML 독립체 호환용 문자열이 들어가 있는 경우가 있는데 이는 `replace`함수로 부터 걸러지게 된다.

##### 댓글 목록 가져오기
`DCComment`는 `<p>(.*?)</p>[\s\S]*?m_list_text"">(.*?)<[\s\S]*?date"">(.*?)<`의 표현식을 가진다. `GetCommentsHtml`함수는 `http://m.dcinside.com/comment_more.php`라는 모바일 주소를 이용해 댓글의 정보를 가져온다. 이에 대한 정보는 Line 353을 참조하라. 송신된 댓글 페이지 조각은 Html로 이루어져 약간의 분석을 요구한다.

##### 페이지/댓글 로드의 절차성


## 기타
#### 게시글의 User Id 에 관하여
얼마전, DCMap에 3번째 항목으로 User Id를 가져올 수 있게 업데이트 하였다. 이 User Id는 level이 `1`또는 `2`일 경우에만 사용된다.

#### 사용되지 않은 함수들
##### GetLastPageFromId
해당 갤러리의 마지막 페이지를 가져온다.
