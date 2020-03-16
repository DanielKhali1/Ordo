import java.io.BufferedWriter;
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;

import javafx.animation.KeyFrame;
import javafx.animation.Timeline;
import javafx.application.Application;
import javafx.event.ActionEvent;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.TextField;
import javafx.scene.layout.Pane;
import javafx.scene.layout.VBox;
import javafx.scene.paint.Color;
import javafx.scene.shape.Rectangle;
import javafx.stage.Stage;
import javafx.util.Duration;

public class Main extends Application
{
	private final int ROWS = 50;
	private final int COLS = 70;
	Pane pane = new Pane();
	Scene scene = new Scene(pane, 1280, 720);		
	Stage stage = new Stage();
	
	Color c = Color.WHITE;

	boolean playerBool = false;
	boolean enemyBool = false;
	boolean buildingBool = false;
	boolean glassBool = false;
	boolean crateBool = false;
	
	boolean clicked = false;
	
	
	public static void main(String args[])
	{
		launch(args);
	}

	Rectangle[][] cells = new Rectangle[ROWS][COLS];
	
	@Override
	public void start(Stage primaryStage) 
	{		
		
		for(int i = 0; i < cells.length; i++)
		{
			for(int j = 0; j < cells[0].length; j++)
			{
				cells[i][j] = new Rectangle(scene.getWidth()/COLS, scene.getHeight()/ROWS);
				cells[i][j].relocate((scene.getWidth()/COLS) * j, (scene.getHeight()/ROWS) * i);
				pane.getChildren().add(cells[i][j]);
				cells[i][j].setFill(c);
				cells[i][j].setStroke(Color.BLACK);
				final int ii = i;
				final int jj = j;
				
				cells[i][j].setOnMouseEntered(e->{
					if(clicked)
					{
						cells[ii][jj].setFill(c);					
					}
				});
				
			}
		}

		
		control();
						
		pane.setOnMouseDragged(e->{
			for(int i = 0; i < cells.length; i++)
			{
				for(int j = 0; j < cells[0].length; j++)
				{
					if(		e.getX() < cells[i][j].getLayoutX() + cells[i][j].getWidth() &&
							e.getX() > cells[i][j].getLayoutX() &&
							e.getY() < cells[i][j].getLayoutY() + cells[i][j].getHeight() &&
							e.getY() >cells[i][j].getLayoutY())
					cells[i][j].setFill(c);					
				}
			}
		});
		pane.setOnMouseClicked(e->{
			for(int i = 0; i < cells.length; i++)
			{
				for(int j = 0; j < cells[0].length; j++)
				{
					if(		e.getX() < cells[i][j].getLayoutX() + cells[i][j].getWidth() &&
							e.getX() > cells[i][j].getLayoutX() &&
							e.getY() < cells[i][j].getLayoutY() + cells[i][j].getHeight() &&
							e.getY() >cells[i][j].getLayoutY())
					cells[i][j].setFill(c);					
				}
			}
		});
		
		primaryStage.setScene(scene);
		primaryStage.setTitle("Tile Map Editor");
		primaryStage.show();
		
		primaryStage.setOnCloseRequest(e->{
			stage.close();
		});
	}
	
	/**
	 * 
	 */
	public void control()
	{
		Pane pane = new Pane();
		Scene scene = new Scene(pane, 300, 500);
		
		VBox vb = new VBox();
		vb.relocate(20, 20);
		vb.setSpacing(20);
		pane.getChildren().add(vb);
		
		Button Player = new Button("Player Spawn");
		vb.getChildren().add(Player);
		
		Button Enemy = new Button("Enemy Spawn");
		vb.getChildren().add(Enemy);
		
		Button Building = new Button("Building Spawn");
		vb.getChildren().add(Building);
		
		Building.setOnAction(e->
		{
			playerBool = false;
			enemyBool = false;
			buildingBool = !buildingBool;
			glassBool = false;
			crateBool = false;
			
			if(buildingBool)
			{
				Player.setStyle("-fx-background-color: 'lightgrey';");
				Enemy.setStyle("-fx-background-color: 'lightgrey';");
				Building.setStyle("-fx-background-color: 'grey';");
				c = Color.BLACK;
			}
			else
			{
				Building.setStyle("-fx-background-color: 'lightgrey';");
				c = Color.WHITE;
			}
		});
		
		TextField fileName = new TextField();
		fileName.setText("Filename");
		vb.getChildren().add(fileName);
		
		Button saveFile = new Button("saveFile");
		vb.getChildren().add(saveFile);
		saveFile.setOnAction(e->{
			
			try 
			{
				saveToFile(fileName.getText());
			}
			catch (Exception e1) 
			{
				e1.printStackTrace();
			}
		});
		
		
		
		Player.setOnAction(e->
		{
			playerBool = !playerBool;
			enemyBool = false;
			buildingBool = false;
			glassBool = false;
			crateBool = false;
			
			if(playerBool)
			{
				Player.setStyle("-fx-background-color: 'green';");
				Enemy.setStyle("-fx-background-color: 'lightgrey';");
				Building.setStyle("-fx-background-color: 'lightgrey';");

				c = Color.GREEN;
			}
			else
			{
				Player.setStyle("-fx-background-color: 'lightgrey';");
				c = Color.WHITE;
			}
		});
		
		Enemy.setOnAction(e->
		{
			playerBool = false;
			enemyBool = !enemyBool;
			buildingBool = false;
			glassBool = false;
			crateBool = false;
			
			if(enemyBool)
			{
				Enemy.setStyle("-fx-background-color: 'red';");
				Player.setStyle("-fx-background-color: 'lightgrey';");
				Building.setStyle("-fx-background-color: 'lightgrey';");

				c = Color.RED;
			}
			else
			{
				Enemy.setStyle("-fx-background-color: 'lightgrey';");
				c = Color.WHITE;
			}
		});
		
		
		
		stage.setX(0);
		stage.setScene(scene);
		stage.show();
		stage.setTitle("Control Pane");
	}
	
	public void saveToFile(String filename) throws Exception
	{
		String fileboi = filename + ".csv";
		
		BufferedWriter bf = new BufferedWriter(new FileWriter(new File(fileboi)));
		String s = "";
		
		
		for(int i = 0; i < cells.length; i++)
		{
			
			for(int j = 0; j < cells[i].length; j ++)
			{
				if(cells[i][j].getFill().equals(Color.WHITE))
					s += " ";
				if(cells[i][j].getFill().equals(Color.GREEN))
					s += "g";
				if(cells[i][j].getFill().equals(Color.RED))
					s += "r";
				if(cells[i][j].getFill().equals(Color.BLACK))
					s += 'b';
				s+=",";
			}
			s+= "\n";
		}
		System.out.println(s);
		bf.write(s);
		bf.close();
		
	}

	
	
	

}
