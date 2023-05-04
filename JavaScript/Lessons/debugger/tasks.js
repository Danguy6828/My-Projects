// let counter = 0; 
// let maxValue = 10; 
// let result = 1; 
 
// debugger; 
// for (counter = 0; counter < maxValue; counter++) { 
//     console.log(result); 
//     result *= maxValue - counter - 1; //remove -1 because it keeps getting reset to 0 when multiplied by 0
// } 
 
// console.log("Final result: ", result);

function max(array) { 
    let maxValue = array[1]; 
    for(let i=0; i<array.length; i++) { // change i=1 to i=0 because it skips the first array value
        if(array[i] > maxValue) { 
            maxValue = array[i]; 
        } 
    } 
    return maxValue; 
} 
 
console.log( max([1, 4, 6, 2])); // -> 6 
console.log( max([10, 4, 6, 2])); // -> 6