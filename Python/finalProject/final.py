import tkinter as tk
import sys, csv, random

window = tk.Tk()

window.geometry('500x150')
window.title('Test of Despair')

def startTest():
    startMenu.destroy()
    examMenu.pack()

def endTest():
    examMenu.destroy()
    resultMenu.pack()

# Each part of the exam is put into frames to easily replace them as the test progresses.
startMenu = tk.Frame(window)
examMenu = tk.Frame(window)
resultMenu = tk.Frame(window)

startMenu.pack()

labelStart = tk.Label(startMenu, text="This quiz is designed to take in your provided input file and record your chosen answers. \n At the end, you will receive your final score. \n If you are ready to begin, please press start. \n")
labelStart.pack()

buttonStart = tk.Button(startMenu, text="START", command= startTest)
buttonStart.pack()

with open(sys.argv[1], newline="") as csvfile:
    reader = csv.DictReader(csvfile)

    questionDatabank = []
    for row in reader:
        question = row["question"]
        correctAnswer = row["answer"]
        decoy1 = row["decoy1"]
        decoy2 = row["decoy2"]
        decoy3 = row["decoy3"]
        answerChoices = [correctAnswer, decoy1, decoy2, decoy3]
        questionDatabank.append((question, answerChoices, correctAnswer))

# Shuffle order of all questions + answers together in the list
random.shuffle(questionDatabank)


# Shuffle order of answers per question indicated by i and the answers list indicated by "1"
for i in range(len(questionDatabank)):
    random.shuffle(questionDatabank[i][1])

currentQuestion = 0
correctCount = 0

# The question that is displayed is defined by the currentQuestion value and then it draws from the questionDatabank first value "0".
label = tk.Label(examMenu, text=questionDatabank[currentQuestion][0])
label.pack()

choices = []

# To check the answer the function looks at the question that is defined by the currentQuestion.
def answerCheck(answer):
    global correctCount

    # The correct answer is recorded in the third value, so that it can be compared even when the answers are shuffled.
    print("The correct answer is: " + questionDatabank[currentQuestion][2])
    print("Your answer was: " + answer + "\n")
    
    # It looks at the 2nd part of the questionDatabank list which is the answers list "1" and compared it to the first item in the list "0".
    if answer == questionDatabank[currentQuestion][2]:
        correctCount += 1

    moveNext()

# This function will display the next question or move onto the results screen depending on how many questions are left.
def moveNext():
    global currentQuestion
    currentQuestion += 1

    if currentQuestion >= len(questionDatabank):
        correctString = str(correctCount)
        totalString = str(len(questionDatabank))

        labelEnd = tk.Label(resultMenu, text="You answered " + correctString + " out of " + totalString + " questions correctly!")
        labelEnd.pack()

        endTest()

    else:
        for i in range(4):
            choices[i].config(text=questionDatabank[currentQuestion][1][i])
            choices[i].config(command=lambda answer=questionDatabank[currentQuestion][1][i]: answerCheck(answer))

        label.config(text=questionDatabank[currentQuestion][0])

# This part adds the answers list as buttons for the questions and then uses the previous function in order to check the answer.
for i in range(4):
    button = tk.Button(examMenu, text="")
    button.pack()
    choices.append(button)

    button.config(command=lambda answer=questionDatabank[currentQuestion][1][i]: answerCheck(answer))

# I had to add this part of the code again at the end because the first question does not have any answers displayed otherwise.
for i in range(4):
    choices[i].config(text=questionDatabank[currentQuestion][1][i])

window.mainloop()
