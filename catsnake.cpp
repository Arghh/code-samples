#include <SFML/Graphics.hpp>
#include <SFML/System.hpp>
#include <stdlib.h>
#include <random>
#include <iostream>
#include <sstream>


class CatSnake
{
  //declear needed variables
private:
  sf::RenderWindow window;
  sf::Sprite player;
  sf::Sprite food;
  sf::Texture catface;
  sf::Texture dreamie;
  sf::Text showScore;
  sf::Text showTime;
  sf::Text gameOver;
  sf::Texture background;
  sf::Sprite back;
  sf::Font font;
  sf::Clock clock;
  int score;
  bool movingLeft, movingUp, movingRight, movingDown, space;

public:
  //game window with player etc automatically created when i create instance of snake class
  CatSnake() : window(sf::VideoMode(800, 600), "CatSnake")
  {
    score = 0;
    window.setFramerateLimit(60);//alternative  Window.EnableVerticalSync(true);
    background.loadFromFile("BACKGROUND-HERE.png");
    catface.loadFromFile("PLAYER-HERE.png");
    dreamie.loadFromFile("FOODPIC-here.png");
    font.loadFromFile("DOWNLOAD AND PLACE THE FONT IN THE GAME FOLDER AND LINK HERE.otf");
    back.setTexture(background);
    player.setTexture(catface);
    player.setTextureRect(sf::IntRect(0,0,58,50));
    player.setPosition(150, 150);
    player.setColor(sf::Color(255, 255, 255, 200));
    food.setTexture(dreamie);
    food.setTextureRect(sf::IntRect(0,0,30,24));
    food.setPosition(250,250);
    showScore.setPosition(10,10);
    showScore.setFont(font);
    showScore.setCharacterSize(24);
    showScore.setColor(sf::Color::Red);
    showTime.setPosition(620,10);
    showTime.setFont(font);
    showTime.setCharacterSize(24);
    showTime.setColor(sf::Color::Red);
  }
  
  void Run()
  { 
    while (window.isOpen())
    {
      //game logic. check if key pressed. move player.
      processEvents();
      playerMove();
      eatFood();
      render();
      if(!timeLeft())
      {
        restartGame();
      }
    }
  }

private:

  	static inline std::string int2Str(float x)
  	  //converts int to string with help of sstream namespace
	{
		std::stringstream type;
		type << x;
		return type.str();
	}

void restartGame()
{
  if(space)
  {
    clock.restart();
    Run();
  }
}

void eatFood()
  {
    //gets players and foods outer boxparameters. if they colide create a new random pos for food.
    sf::FloatRect playerbox = player.getGlobalBounds();
    sf::FloatRect foodbox = food.getGlobalBounds();
    if(playerbox.intersects(foodbox))
    {
      int posx = rand() %790 + 1;
      int posy = rand() %590 + 1;
      score++;
      clock.restart();
      food.setPosition(posx,posy);
    }
    showScore.setString("Score: " + int2Str(score));
  }

bool timeLeft()
{
  //add a timecounter to run down
    const float timeRemaining = 5.f;
    sf::Time elapsed1 = clock.getElapsedTime();
    float sec  = elapsed1.asSeconds();
    float timeLeft = timeRemaining - sec;
    if(timeLeft > 0)
    {
      showTime.setString("Time: " + int2Str(timeLeft));
      return true;
    }
    else
    {
    //create a gameover string
      gameOver.setPosition(150,180);
      gameOver.setFont(font);
      gameOver.setCharacterSize(94);
      gameOver.setColor(sf::Color::Red);
      gameOver.setString("GAME OVER");
      showTime.setString("Time up");
      return false;
    }
}

  void handlePlayerInput(sf::Keyboard::Key key, bool isPressed)
  {
    movingDown = false;
    movingLeft = false;
    movingRight = false;
    movingUp = false;
    space = false;
    if (key == sf::Keyboard::Up) 
      movingUp = isPressed;
    else if (key == sf::Keyboard::Down) 
      movingDown = isPressed;
    else if (key == sf::Keyboard::Left) 
      movingLeft = isPressed;
    else if(key == sf::Keyboard::Right) 
      movingRight = isPressed;
    else if(key == sf::Keyboard::Space)
      space = isPressed;
  }

  void playerMove()
  { 
    //all values actually floats f.e -1.f and 1.f 
    if(movingUp)
    {
      if(player.getPosition().y < 0)
      {
        player.move(0,0);
      }
      else
      {
        player.move(0,-7);
      }
    }

    if(movingLeft)
    {
      if(player.getPosition().x < 0)
      {
        player.move(0,0);
      }
      else
      {
        player.move(-7,0);
      }
    }

    if(movingDown)
    {
      if(player.getPosition().y > 580)
      {
        player.move(0,0);
      }
      else
      {
        player.move(0,7);
      }
    }

    if(movingRight)
    {
      if(player.getPosition().x > 780)
      {
        player.move(0,0);
      }
      else
      {
        player.move(7,0);
      }
    }
  }

  void processEvents()
  {
    //sfml event logic.
    sf::Event event;
    while (window.pollEvent(event))
    {
      switch(event.type)
      {
        //if i click something keep rendering if not stop
      case sf::Event::KeyPressed : handlePlayerInput(event.key.code, true); 
        break;
    // case sf::Event::KeyReleased : handlePlayerInput(event.key.code, false); ///makes the player stop moving if key is released.
        break;
      case sf::Event::Closed : window.close();
        break;
      }
    }
  }
  void render()
  {
    //clear old draw new place and show
    window.clear();
    window.draw(back); //background find a optimal way of doing this
    if(timeLeft())
    {
      window.draw(player);
    }
    if(timeLeft())
    {
      window.draw(food);
    }
    window.draw(showScore);
    window.draw(showTime);
    if(!timeLeft())
    {
      window.draw(gameOver);
    }
    window.display();
  }
};

int main()
{
//minimal game function
  srand(time(0));
  CatSnake game;
  game.Run();

  return 0;
}
