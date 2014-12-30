Let's Play Battleship!
======================

<p><strong>To play:</strong></p>
<ol>
<li>Clone this repo.</li>
<li>Edit the MyStratgey class (or create a new one) to be FirstLastStrategy (mine would be GregDickStrategy).</li>
<li>Determine the placement of your pieces in your strategy class.</li>
<li>Create your algorithm in the GetNextMove method of your strategy. You have access to a lot of information in the context, as well as some utility in the Util class.</li>
<li>Email me your file. Do not create a pull request for it, or other people will see your strategy.</li>
</ol>

<p><strong>How to test your strategy:</strong><p>
<p>You can run the main method in Program to test your strategy against boards with randomly placed ships. Your average number of moves to victory will be important for the main event as detailed below.</p>

<p><strong>How it'll go down:</strong></p>
<p>All strategies will be tested against 1000 boards with randomly placed ships. They will each receive a score that is their average number of moves to victory. This will seed the strategies into a tournament bracket.</p>
<p>After all strategies have been placed into the bracket, each match will pit the two strategies against each other where they will play a real game of battleship. This is where your ship placement will be used. The higher seeded strategy will get the first move.</p>
<p>The winner of the bracket will be declared the battleship champion.</p>
