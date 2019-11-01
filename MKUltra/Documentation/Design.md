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
			
