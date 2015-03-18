using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	static public int [,] Chess;
	public int Dpeth;
	public  GameObject[] Chess_Array;

	private int Player = 0;
	private int HumanScore = 0;
	private int ComputerScore = 0;

	private string display_text = "";
	void Start () {
		Player = 1;
		Chess = new int[6,6];
		Chess_Array = GameObject.FindGameObjectsWithTag("Chess");
	}

	void Update () {
		if( Player % 2 == 0 ){
			int [,]chess_temp;
			chess_temp = new int[6, 6];
			System.Array.Copy(Chess, chess_temp, 6 * 6 );
			maxi ( chess_temp, 6, 6, Dpeth, 0, 0 );

			for( int i = 0; i < 6; i ++ ){
				for( int j = 0; j < 6; j ++ ){
					Chess chess = Chess_Array[i*6 + j].GetComponent<Chess>();
					int x = chess.GetX();
					int y = chess.GetY();
					if( Chess[x,y] == -1 ){
						Chess_Array[i*6 + j].renderer.material.color = Color.red;
						chess.SetChess(x,y);
					}
				}
			}
			ComputerScore = ScoreCal( Chess,6,6,Player);
			
			Player++;
		}
		if( Input.GetMouseButtonDown(0)){
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if( Physics.Raycast(ray,out hit,100.0f)){
				if( Player % 2 == 0 ){
				}
				else{
				//Me
					Chess chess = hit.collider.gameObject.GetComponent<Chess>();
					if( !chess.hasSet()){
						hit.collider.gameObject.renderer.material.color = Color.blue;

						int x = chess.GetX();
						int y = chess.GetY();
						Chess[x,y] = 1;
						chess.SetChess(x,y);

						HumanScore = ScoreCal( Chess,6,6,Player);
						Player++;
					}
				}
			}
		}

		GameEndCheck( Chess,6,6);

	}
	bool CheckWin(int [,] chess, int width, int height){
		if( width < 0 || height < 0 ){
			Debug.LogError("Check win wrongly");
			return false;
		}
		for( int i = 0; i < width; i ++ ){
			for( int j = 0; j < height; j++){
				if( chess[i,j] == 0 ) return false;
			}
		}
		return true;
	}


	void GameEndCheck(int [,]chess, int width, int height){
		if( width < 0 || height < 0 ){
			Debug.LogError("Minmax wrongly");
			return ;
		}
		if( CheckWin( chess, width, height)){
			if( HumanScore > ComputerScore ){
				display_text = "You win!";
			}
			else if( HumanScore < ComputerScore ){
				display_text = "I win!";
			}
			else{
				display_text = "Again";
			}
		}
		return;
	}

	int maxi( int [,]chess, int width, int height, int depth, int a, int b){
		if(depth == 0 ) return evaluation( chess, width, height );
		
		int max = -9999;
		int score = 0;
		int i_x = 0;
		int i_y = 0;

		for( int i = 0; i < width; i ++ ){
			for( int j = 0; j < height; j++){
				if( chess[i,j] == 0 ) {
					chess[i,j] = -1;
					score = mini ( chess, width, height, depth - 1, a, b);
					if( score < 0 ){
						//if( depth != Dpeth ) break;
					}
					chess[i,j] = 0;
					if( score > max ){
						max = score;
						i_x = i;
						i_y = j;
					}
				}
			}
		} 
		if( depth == Dpeth ) Chess[i_x, i_y] = -1;
		return max;
	}

	int mini( int [,]chess, int width, int height, int depth, int a, int b){
		if(depth == 0 ) return evaluation( chess, width, height );

		int min = 9999;
		int score = 0;
		int i_x = 0;
		int i_y = 0;

		for( int i = 0; i < width; i ++ ){
			for( int j = 0; j < height; j++){
				if( chess[i,j] == 0 ) {
					chess[i,j] = 1;
					score = maxi ( chess, width, height, depth - 1, a, b);
					chess[i,j] = 0;
					if( score < min ){
						min = score;
						i_x = i;
						i_y = j;
					}
				}
			}
		} 
		if( depth == Dpeth ) Chess[i_x, i_y] = 1;
		return min;
	}

	int evaluation(int [,]chess, int width, int height){
		if( width < 0 || height < 0 ){
			Debug.LogError("evaluation wrong");
			return -1;
		}

		//int result = ScoreCal (chess, width, height, 2) - ScoreCal (chess, width, height, 1);
		int result = 5 * FiveScoreCal(chess, width, height, 2) + 4 * ScoreCal (chess, width, height, 2) + 3 * ThreeScoreCal(chess, width, height, 2) - 
			( 3 * ThreeScoreCal(chess, width, height, 1) + 4 * ScoreCal (chess, width, height, 1) + 5 * FiveScoreCal(chess, width, height, 1));
		//AI score - player score
		if (result < 0) {
			//Debug.Log("hehe");
		}
		return result;
	}
	int FiveScoreCal( int [,]chess, int x, int y, int Player){
		int score = 0;
		for(int i = 0; i < x; i++ ){
			for(int j = 0; j < y; j++){
				if(Player % 2 == 0){
					//Computer
					if( chess[i,j] == -1 ){
						//Right line 
						if( j + 4 <= 5 ){
							if( chess[i,j] == -1 && chess[i,j+1] == -1
							   && chess[i,j+2] == -1 && chess[i, j+3] == -1 && chess[i, j+4] == -1){
								score++;
							}
						}
						// Down Line
						if( i + 4 <= 5){
							if( chess[i,j] == -1 && chess[i + 1,j] == -1
							   && chess[i + 2,j] == -1 && chess[i + 3, j] == -1&& chess[i + 4, j] == -1){
								score++;
							}
						}
						// Down right line
						if( i + 4 <= 5 && j + 4 <= 5 ){
							if( chess[i,j] == -1 && chess[i + 1,j + 1] == -1
							   && chess[i + 2,j + 2] == -1 && chess[i + 3, j + 3] == -1 && chess[i + 4, j + 4] == -1){
								score++;
							}
						}
						// Down left line
						if( i + 4 <= 5 && j - 4 >= 0 ){
							if( chess[i,j] == -1 && chess[i + 1,j - 1] == -1
							   && chess[i + 2,j - 2] == -1 && chess[i + 3, j - 3] == -1 && chess[i + 4, j - 4] == -1){
								score++;
							}
						}
					}
				}
				else{
					//Me
					if( chess[i,j] == 1 ){
						//Right line 
						if( j + 4 <= 5 ){
							if( chess[i,j] == 1 && chess[i,j+1] == 1
							   && chess[i,j+2] == 1 && chess[i, j+3] == 1 && chess[i, j+4] == 1){
								score++;
							}
						}
						// Down Line
						if( i + 4 <= 5){
							if( chess[i,j] == 1 && chess[i + 1,j] == 1
							   && chess[i + 2,j] == 1 && chess[i+3, j] == 1 && chess[i+4, j] == 1){
								score++;
							}
						}
						// Down right line
						if( i + 4 <= 5 && j + 4 <= 5 ){
							if( chess[i,j] == 1 && chess[i + 1,j + 1] == 1
							   && chess[i + 2,j + 2] == 1 && chess[i + 3, j + 3] == 1 && chess[i + 4, j + 4] == 1){
								score++;
							}
						}
						// Down left line
						if( i + 4 <= 5 && j - 4 >= 0 ){
							
							if( chess[i,j] == 1 && chess[i + 1,j - 1] == 1
							   && chess[i + 2,j - 2] == 1 && chess[i + 3, j - 3] == 1 && chess[i + 4, j - 4] == 1){
								score++;
							}
						}
					}
				}
			}
		}
		return score;
	}
	
	int ScoreCal( int [,]chess, int x, int y, int Player){
		int score = 0;
		for(int i = 0; i < x; i++ ){
			for(int j = 0; j < y; j++){
				if(Player % 2 == 0){
					//Computer
					if( chess[i,j] == -1 ){
						//Right line 
						if( j + 3 <= 5 ){
							if( chess[i,j] == -1 && chess[i,j+1] == -1
							   && chess[i,j+2] == -1 && chess[i, j+3] == -1){
								score++;
							}
						}
						// Down Line
						if( i + 3 <= 5){
							if( chess[i,j] == -1 && chess[i + 1,j] == -1
							   && chess[i + 2,j] == -1 && chess[i + 3, j] == -1){
								score++;
							}
						}
						// Down right line
						if( i + 3 <= 5 && j + 3 <= 5 ){
							if( chess[i,j] == -1 && chess[i + 1,j + 1] == -1
							   && chess[i + 2,j + 2] == -1 && chess[i + 3, j + 3] == -1){
								score++;
							}
						}
						// Down left line
						if( i + 3 <= 5 && j - 3 >= 0 ){
							if( chess[i,j] == -1 && chess[i + 1,j - 1] == -1
							   && chess[i + 2,j - 2] == -1 && chess[i + 3, j - 3] == -1){
								score++;
							}
						}
					}
				}
				else{
					//Me
					if( chess[i,j] == 1 ){
						//Right line 
						if( j + 3 <= 5 ){
							if( chess[i,j] == 1 && chess[i,j+1] == 1
							   && chess[i,j+2] == 1 && chess[i, j+3] == 1){
								score++;
							}
						}
						// Down Line
						if( i + 3 <= 5){
							if( chess[i,j] == 1 && chess[i + 1,j] == 1
							   && chess[i + 2,j] == 1 && chess[i+3, j] == 1){
								score++;
							}
						}
						// Down right line
						if( i + 3 <= 5 && j + 3 <= 5 ){
							if( chess[i,j] == 1 && chess[i + 1,j + 1] == 1
							   && chess[i + 2,j + 2] == 1 && chess[i + 3, j + 3] == 1){
								score++;
							}
						}
						// Down left line
						if( i + 3 <= 5 && j - 3 >= 0 ){

							if( chess[i,j] == 1 && chess[i + 1,j - 1] == 1
							   && chess[i + 2,j - 2] == 1 && chess[i + 3, j - 3] == 1){
								score++;
							}
						}
					}
				}
			}
		}
		return score;
	}

	int ThreeScoreCal( int [,]chess, int x, int y, int Player ){
		int score = 0;
		for(int i = 0; i < x; i++ ){
			for(int j = 0; j < y; j++){
				if(Player % 2 == 0){
					//Computer
					if( chess[i,j] == -1 ){
						//Right line 
						if( j + 2 <= 5 ){
							if( chess[i,j] == -1 && chess[i,j+1] == -1
							   && chess[i,j+2] == -1 ){
								score++;
							}
						}
						// Down Line
						if( i + 2 <= 5){
							if( chess[i,j] == -1 && chess[i + 1,j] == -1
							   && chess[i + 2,j] == -1 ){
								score++;
							}
						}
						// Down right line
						if( i + 2 <= 5 && j + 2 <= 5 ){
							if( chess[i,j] == -1 && chess[i + 1,j + 1] == -1
							   && chess[i + 2,j + 2] == -1 ){
								score++;
							}
						}
						// Down left line
						if( i + 2 <= 5 && j - 2 >= 0 ){
							if( chess[i,j] == -1 && chess[i + 1,j - 1] == -1
							   && chess[i + 2,j - 2] == -1 ){
								score++;
							}
						}
					}
				}
				else{
					//Me
					if( chess[i,j] == 1 ){
						//Right line 
						if( j + 2 <= 5 ){
							if( chess[i,j] == 1 && chess[i,j+1] == 1
							   && chess[i,j+2] == 1){
								score++;
							}
						}
						// Down Line
						if( i + 2 <= 5){
							if( chess[i,j] == 1 && chess[i + 1,j] == 1
							   && chess[i + 2,j] == 1 ){
								score++;
							}
						}
						// Down right line
						if( i + 2 <= 5 && j + 2 <= 5 ){
							if( chess[i,j] == 1 && chess[i + 1,j + 1] == 1
							   && chess[i + 2,j + 2] == 1 ){
								score++;
							}
						}
						// Down left line
						if( i + 2 <= 5 && j - 2 >= 0 ){
							
							if( chess[i,j] == 1 && chess[i + 1,j - 1] == 1
							   && chess[i + 2,j - 2] == 1 ){
								score++;
							}
						}
					}
				}	
			}
		}
		return score;
	}

	void OnGUI(){
		GUI.skin.label.fontSize = 50;
		GUI.Label(new Rect(Screen.width/2 - 400,100,600,100),"U "+ HumanScore.ToString());
		GUI.Label(new Rect(Screen.width/2 + 300,100,600,100),"H "+ ComputerScore.ToString());
		GUI.Label(new Rect(Screen.width/2 ,400,600,100), display_text.ToString());
	}
}
