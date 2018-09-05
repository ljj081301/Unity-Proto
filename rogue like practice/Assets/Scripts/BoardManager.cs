using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//유니티내의 랜덤 네임스페이스
using Random = UnityEngine.Random;


public class BoardManager : MonoBehaviour {

    //최소치, 최대치 클래스
    [Serializable]
    public class Count
    {
        public int minimum;
        public int maximum;

        //카운트 함수 정의, min, max 설정)
        public Count(int min, int max)
        {
            minimum = min;
            maximum = max;
        }
    }

    //플레이맵의 전체 크기
    public int columns = 8;
    public int rows = 8;

    //벽과 음식의 랜덤 생성 범위 지정
    public Count wallCount = new Count(5, 9);
    public Count foodCount = new Count(1, 5);

    //게임 오브젝트 생성
    public GameObject exit;
    public GameObject[] floorTiles;
    public GameObject[] wallTiles;
    public GameObject[] foodTiles;
    public GameObject[] outerWallTiles;
    public GameObject[] enerymyTiles;

    //?
    private Transform boardHolder;
    //3차원 공간의 리스트 변수
    private List<Vector3> gridPositions = new List<Vector3>();

    //초기 리스트 생성 함수
    void InitializeList()
    {
        //충돌막기위해 시작전 클리어
        gridPositions.Clear();

        //최대 가로길이보다 작을때까지, 최대 세로길이보다 작을때까지 for루프
        for (int x = 1; x < columns - 1; x++)
        {
            for (int y = 1; y < rows - 1; y++)
            {
                //그리드위치에 현재 x,y좌표를 추가
                gridPositions.Add(new Vector3(x, y, 0f));
            }
        }
    }

    //보드 생성 함수
    void BoardSetup()
    {
        //보드 홀더 변수를 프로젝트내 "Board"오브젝트와 동기화
        boardHolder = new GameObject("Board").transform;

        //각각 x,y좌표 루프 => 전체좌표마다
        for (int x = 1; x < columns + 1; x++)
        {
            for (int y = 1; y < rows + 1; y++)
            {
                //플로어 타일리스트중 랜덤하게 뽑
                GameObject toInstantiate = floorTiles[Random.Range(0, floorTiles.Length)];

                if (x == -1 || x == columns || y == -1 || y == rows)
                {
                    //만약 벽에 도달하면 월타일로 변경
                    toInstantiate = outerWallTiles[Random.Range(0, outerWallTiles.Length)];
                }
                //?
                GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;

                //인스턴스를 보드 홀더의 자식으로 편입
                instance.transform.SetParent(boardHolder);

            }
        }


    }

    //랜덤 위치를 뽑는 함수
    Vector3 RandomPosition()
    {
        //그리드 위치중 랜덤하게 뽑아 인덱스 저장
        int randomIndex = Random.Range(0, gridPositions.Count);
        //인덱스에 해당하는 좌표를 벡터3 변수에 저장
        Vector3 randomPosition = gridPositions[randomIndex];
        //이번에 뽑은 위치를 리스트에서 지움(같은 위치에 여러 오브젝트가 위치되지 않게 하기위함)
        gridPositions.RemoveAt(randomIndex);
        //뽑은 위치를 반환
        return randomPosition;
    }

    //실제로 오브젝트를 배치하는 함수
    void LayoutObjectAtRandom(GameObject[] tileArray, int minimum, int maximum)
    {
        //오브젝트를 몇개놓을지 랜덤하게 정하는 변수
        int objectCount = Random.Range(minimum, maximum + 1);

        //정해진 오브젝트의 갯수만큼 반복
        for (int i = 0; i<objectCount; i++)
        {
            //랜덤포지션 함수 돌려서 리턴값 저장
            Vector3 randomPosition = RandomPosition();
            //타일리스트중 랜덤하게 하나 선택
            GameObject tileChoice = tileArray[Random.Range(0,tileArray.Length)];
            //고른 타일을 해당 위치에 배치?
            Instantiate(tileChoice, randomPosition, Quaternion.identity);
        }
    }


    public void SetupScene(int level)
    {
        BoardSetup();
        InitializeList();
        //벽과 음식 오브젝트를 배치
        LayoutObjectAtRandom(wallTiles, wallCount.minimum, wallCount.maximum);
        LayoutObjectAtRandom(foodTiles, foodCount.minimum, foodCount.maximum);
        //레벨에 따라 로그함수를 따라서 적의 수가 증가
        int enermyCount = (int)Mathf.Log(level, 2f);
        //랜덤 위치에 적의 숫자 만큼 배치
        LayoutObjectAtRandom(enerymyTiles, enermyCount, enermyCount);
        //우측 최상단에 출구 배치
        Instantiate(exit, new Vector3(columns - 1, rows - 1, 0F), Quaternion.identity);
    }
}
