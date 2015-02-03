/*The game of FizzBuzz.
Rules: instead of saying numbers divisible by 3, say "Fizz". And instead of saying numbers divisible by 5, say "Buzz". 
For numbers divisible by both 3 and 5, say "FizzBuzz". "1, 2, Fizz, 4, Buzz"...and so forth.*/
 for (i = 1; i <= 20; i++) {
        if (i % 3 == 0 && i % 5 == 0) {
        console.log("FizzBuzz");
    } else if (i % 5 == 0) {
        console.log("Buzz");
    } else if (i % 3 == 0) {
        console.log("Fizz");
    }

    else {
        console.log(i);
    }

};
