Team Challenge Two:

Team USA has been losing speed wars to Team Timbuktu in the global games of speed typing. All the US tech leaders including Bezos, Gates, and Zuckerberg have put in their resources to recruit developers to build a speed typing game. The game will be the official trainer for Team USA as they try to get back on top of the world against Team Timbuktu. This game should be able to measure typing speed per minute. The user should be able to keep track of their overall progress as they complete the timed test. Your goal should you choose to accept this is to make this game addicting where Team USA players will want to always be typing on it and improving their speed.

ViewModel

The ViewModel will serve as the bridge between the data Models and the View. The ViewModel contains ObservableCollections of both Players and Challenges, so that changes to the properties of both models can be propogated to the View. The ViewModel also contains several properties utilizing the INotifyPropertyChanged Interface, which enables bidirectional databinding between the ViewModel and View. User actions are handled using a combination of ICommands and EventHandlers, which enables the decoupling of user interface control objects from the ViewModel interactions. 



Challenge/Lesson Model

Lessons will consist of a block of text.

Player
-two types, human and AI
	-AI
		-array of inputs and a time for each, generated for each lesson
		-difficulty(typing rate, will divide number of characters into a ) or 
		-Race your time, 
	-Human
		-Player History
			-wins
			-losses
			-Each lesson will be saved live, each keypress needs a time, so that you can "ghost" race
			-Record number of mistakes for each lesson


View

The View will be the visual interface displayed to the user. The View will provide the following:

1. An option to select a challenge
2. A way to start the selected challenge
3. Two means of displaying text to the user, with an option to switch between them:
	a. A fixed text block ( or blocks, as space allows) to display the text for the user to type. For this option, there will be a visual indicator of the user's progress through the text. There will also be a visual indicator of the AI's progress. With this option, the user will be able to see all of the text for the challenge.
	b. A scrolling text block to display the text for the user to type. As with the fixed text block, the user's progress through the text will be indicated visually. The AI's progress may or may not be displayed, depending on where the AI is in the text.
4. A secondary progress view, which will be separate from the text view. This secondary view will take the form of a race track, where a player icon will move relative to how many words have been typed. Similarly, AI icons will also move through the race track at a rate commensurate with the course's difficulty level.
5. A timer indicating how long the user has spent on the level
5. A display of the user's words per minute
6. Optionally, a display if other relevant statistics, e.g. accuracy
7. A completion view to display at the end of the challenge
	a. At a minimum, displays player vs. AI scores
8. Upon challenge completion, the view will provide an option for the user to replay the previous challenge, or select a new one.





