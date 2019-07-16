#GameDrones#
##ASP.NET Core and Angular##
Games of Drones is a Web application based on the game Rock, Paper and Scissors and developed using ASP.NET Core and Angular as a front-end framework.
##Description##
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
The website follows the next behavior:
<ol>
	<li>Inputs for each player to enter his name. (Only two players) and a start button to begin the game.</li>
	<li>Once the game begins, each player chooses one of the possible moves.</li>
	<li>Repeats until one of the players wins three times. This player will be the winner of the game.</li>
	<li>Once the game has finished, a Play Again button shows to start a new game.</li>
</ol>
###Game statistics###
The result of each game is stored to keep track of games won by each player. The game displays how many games a player has won.
##Technologies:##
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
#IMPORTANT DETAILS FOR RUNNING THE APPLICATION#
<ul>
  <li>Edit the server name property located at GameDrones.Web/appsettings.json</li>
  <li>If you want to run the automated tests, dit the server name value in the constants ConnectionString located at GameDrones.Data.Tests/ContextTests.cs</li>
</ul>