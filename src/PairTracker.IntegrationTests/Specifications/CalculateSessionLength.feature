Feature:  Calculate Session Length
	In order to asses how well I am pairing
	As a programmer
	I want the system to calculate the length of the session

Scenario: No Activity for 10 seconds
Given a new session
When the session is started
And 10 seconds elapses
And the session is stopped
Then the session length is 10 seconds

Scenario: 2 programmers each control for 5 seconds
Given a new session
When the session is started
And Programmer 1 takes control
And 5 seconds elapses
And Programmer 2 takes control
And 5 seconds elapses
And the session is stopped
Then the session length is 10 seconds

Scenario: 2 programmers each control for 5 seconds with a 5 second pause in between
Given a new session
When the session is started
And Programmer 1 takes control
And 5 seconds elapses
And the session is paused
And 5 seconds elapses
And the session is resumed
And Programmer 2 takes control
And 5 seconds elapses
And the session is stopped
Then the session length is 10 seconds