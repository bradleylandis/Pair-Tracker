Feature:  Interval Creation
	In order to asses how well I am pairing
	As a programmer
	I want the system to create a new interval each time control switches between programmers

Scenario: Empty Session
Given a new session has been started
When the session is stopped
Then the session contains 1 interval

Scenario: 1 programmer controls for the entire session
Given a new session has been started
And Programmer 1 takes control
When the session is stopped
Then the session contains 2 intervals