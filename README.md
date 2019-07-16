# GameDrones
## ASP.NET CORE and Angular
Games of Drones is a Web application based on the game Rock, Paper and Scissors and developed using ASP.NET Core and Angular as a front-end framework.
## Description
In Game of Drones there are two players trying to conquer each other. 
<br/>
Players take turns to make their move, choosing Paper, Rock or Scissors. Each move beats another, just like the game “Paper, rock, scissors”. 
<br/>
Like so:
<ul>
	<li>Paper beats Rock</li>
	<li>Rock beats scissors</li>
	<li>Scissors beat Paper</li>
</ul>
The first player to beat the other player 3 times wins the battle.
<br/>
The website must have the following behavior:
<ol>
	<li>Inputs for each player to enter his name. (Only two players) and a start button to begin the game.</li>
	<li>Once the game begins, each player choose one of the possible moves.</li>
	<li>Once the game begins, each player choose one of the possible moves.</li>
	<li>
		<ul>
			<li>First, player1 pick his move, then player2.</li>
			<li>The system computes the result of the play.</li>
			<li>(The game happens on the same computer for both players. It is not required to create a true online game. Both players share the computer, and the system asks each player for their move assuming the other player looks away while the other selects the move)</li>
			<li>The result of each round should be displayed somewhere in the screen, so that players can know the game score while they are playing.</li>
			<li></li>
		</ul>
	</li>
	<li>Step #2 repeats until one of the players wins three times. This player will be the winner of the game.</li>
	<li>Once the game has finished, a Play Again button shows to start a new game.</li>
</ol>
###Game statistics
The result of each game should be stored to keep track of games won by each player. We would like to know how many games a player has won and show them in a page.
## Technologies:
<ul>
  <li>ASP.NET Core</li>
  <li>SQL Server</li>
  <li>EntityFramework Code-First</li>
  <li>Angular</li>
  <li>Dependency Injection</li>
  <li>NLog</li>
  <li>xUnit</li>
  <li>Moq</li>
  <li>AutoFixture</li>
</ul>

#IMPORTANT FOR RUNNING THE APPLICATION
<ul>
  <li>Edit the server name property located at GameDrones.Web/appsettings.json</li>
  <li>If you want to run the automated tests, dit the server name value in the constants ConnectionString located at GameDrones.Data.Tests/ContextTests.cs</li>
</ul>
