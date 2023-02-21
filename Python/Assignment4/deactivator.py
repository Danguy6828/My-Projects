import numpy, math

dataBase = numpy.fromfile('packet_base.txt', sep = '\n', dtype = float)

dataWeight = numpy.fromfile('packet_weight.txt', sep = '\n', dtype = float)

dataSplitA = numpy.array_split(dataBase, 4096) #use 8 for test

dataSplitB = numpy.array_split(dataWeight, 4096) #use 8 for test

dataMulty = numpy.multiply(dataSplitA, dataSplitB)

arrayMin = numpy.amin(dataMulty, axis = 1)

arrayMax = numpy.amax(dataMulty, axis = 1)

arrayMean = numpy.mean(dataMulty, axis = 1)

##(max - mean) * min
resultsP2 = ((arrayMax - arrayMean) * arrayMin)

chunksSum = math.floor(numpy.sum(resultsP2))

result = chunksSum % 4096

print(result)