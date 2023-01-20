targetNumber = 0
minRange = 0
maxRange = 0

while True:
    try:
        targetNumber = input("What number would you like to use from 1 to 10? (enter 0 to exit): ")
        targetNumber = int(targetNumber)

        if targetNumber > 10 or targetNumber < 0:
            print("That is not a valid number, please enter a number that is between 1 to 10 (or type 0 to exit)")
            
        elif targetNumber == 0:
            break

        else:
            x = True
            while x == True:
                try:
                    minRange = input("Please insert a minimum range to multiply your number with: ")
                    minRange = int(minRange)
                    x = False
                except ValueError:
                    print("Please enter a valid whole number.")
                    x = True
                
            y = True
            while y == True:
                try:
                    maxRange = input("Please insert a maximum range to multiply your number with: ")
                    maxRange = int(maxRange)
                    y = False
                except ValueError:
                    print("Please enter a valid whole number.")
                    y = True

            for line in range(minRange, maxRange + 1):
                print(f"{targetNumber} * {line} = {targetNumber*line}")

    except ValueError:
        print("Please enter a valid whole number.")
