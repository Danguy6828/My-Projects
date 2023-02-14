import unittest
from Student import Student, Assignment, Event

As1 = Assignment('Assignment 1', 80, 100, 'Homework')
As2 = Assignment('Assignment 2', 100, 100, 'Homework')
As3 = Assignment('Exam 1', 281, 300, 'Exam')
As4 = Assignment('Exam 2', 279, 300, 'Exam')


Ev1 = Event('Lecture 1', 'lecture', 0)
Ev2 = Event('Lecture 2', 'lecture', 0)
Ev3 = Event('Meeting 1', 'meeting', 0)
Ev4 = Event('Pot Luck', 'party', 15)


class UnitTests(unittest.TestCase):
    def test_getPercentage(self):
        assignments = [
            [['Assignment 1', 80, 100], 0.80],
            [['Assignment 2', 100, 100], 1],
            [['Exam 1', 281, 300], 0.94],
            [['Exam 2', 279, 300], 0.93]
        ]

        for arguments, checkValue in assignments:
            percent = Assignment(*arguments)

            self.assertEqual(round(percent.getPercentage(), 2), checkValue)
        
        ##Alternate
        ##assignment = As1

        ##self.assertEqual(round(assignment.getPercentage(), 2), 0.8)   

    def test_addEvent(self):
        eventList = [Ev1, Ev2, Ev3, Ev4]
        events = []

        eventInfo = Student(
            name = 'Matthew',
            ID = 'h735f787',
            nickname = 'alex',
            events = events
        )

        for event in eventList:
            eventInfo.addEvent(event)

        self.assertEqual(len(events), 4)

    def test_countMeetings(self):
        eventInfo = Student(
            name = 'Matthew',
            ID = 'h735f787',
            nickname = 'alex',
            events = [Ev1, Ev2, Ev3, Ev4]
        )

        self.assertEqual(eventInfo.countEventOfType('lecture'), 2)
        self.assertEqual(eventInfo.countEventOfType('meeting'), 1)

    def test_getGrade(self):
        gradeInfo = Student(
            name = 'Matthew',
            ID = 'h735f787',
            nickname = 'alex',
            assignments = [As1, As2, As3, As4]
        )

        self.assertEqual(round(gradeInfo.getGrade(), 2), 0.93)

    def test_letterGrade(self):
        gradeInfo = Student(
            name = 'Matthew',
            ID = 'h735f787',
            nickname = 'alex',
            assignments = [As1, As2, As3, As4]
        )

        self.assertEqual(gradeInfo.getLetterGrade(), 'A')

if __name__ == '__main__':
    unittest.main()