# PrimeNumbersTable

__Coding exercise that generates a table based on a succession of N prime numbers__

####Requirements of the exercise

* Write an application that takes numeric input (N) from a user and outputs a multiplication table of (N) prime numbers.
* The user should input a whole number N, where is N is at least 1
* The application should output an N+1 x N+1 grid of numbers
* Please write an algorithm to solve the prime number generation - do not use a library method to generate your primes
* For the input and output you can use the console, a web page, or something else
* Write your application with high unit test coverage

Example output:

<table>
  <tr>
    <td></td><td>2</td><td>3</td><td>5</td>
  </tr>
  <tr>
    <td>2</td><td>4</td><td>6</td><td>10</td>
  </tr>
  <tr>
    <td>3</td><td>6</td><td>9</td><td>15</td>
  </tr>
  <tr>
    <td>5</td><td>10</td><td>15</td><td>25</td>
  </tr>  
</table>

In the above example the 2nd prime number is 3 and the 3rd prime number is 5. So the number in the 3rd row and 4th column should be 15 (because that’s 3 x 5)


####How to run it

* The implementation is an ASP.NET MVC5 website developed in Visual Studio 2015 Community Edition
* To run the site just download the solution in Visual Studio, build it and run it to use the application in a web browser
* The solution contains a set of unit tests implemented using NUnit
* Also, the solution uses NLog for logging operations. Please make sure before running the application that you specify a valid path for the log output on the NLog.config file


####What I am pleased with about my implementation

* First of all, the implementation does fullfil the criteria in terms of input and output values
* I think I've achieved a decent separation of concerns between the generation of the prime numbers by an implemented algorith in code (not from a library, as requested) and then the presentation of the table result
* I initially wanted to implement a solution that would not involve constructing a two-dimensional array of numbers (containing all the data for the final table to be displayed) and would only have to deal with a single array of numbers instead. This should save quite a bit of memory when going for high numbers as we would only need to store N numbers in memory as opposed to N^2. I think I've managed to achieve that with my implementation
* Some caching refinements that I later added into the algorithm and the controller should help in improving performance comparing to the initial implementation
* There is some basic logging in place too, which would help to evaluate performance based on the lenght of time the logged processes take to run and the input provided. Apart from the obvious monitoring benefits for the application
* The unit tests added should cover the most relevant parts of the functionality
* The data annotations and client validation capabilities provided by ASP.NET MVC5 out of the box make easy to take care of those parts  wthout having to implement much custom logic to validate the input values, so it made sense to make use of it instead of going for other approaches (a console app for example) in which some additional custom validation logic and effort may be required
* There are also some good examples of using the Inversion of Control pattern and dependency injection, facilitated by the use of an IoC container with StructureMap
* In terms of extensibility, it should be straigh forward to extend the service class to make use of additional implementations of prime number generation algorithms, for example by creating an algorithm factory that would return one particular implementation of IPrimeNumbersListGeneratorAlgorithm or another depending on some criteria


####What I would do if I had more time

* As soon as I managed to render the table, I realized that the most obvious challenge would be on the presentation of this data. If it only were about displaying the first few prime numbers then it should be much easier, but when going into the hundreds of primes then we're talking about starting to require rendering a grid of tens of thousands of cells and that makes the rendering of the grid much slower. So even though the prime generation algorithm handles much bigger numbers, there must be a practical and fairly low limit on the number of primes that the front-end presentation should handle before going for a different approach to present the data. I've therefore limited the input value to calculate up to the first 500 prime numbers by default. But even that amount makes the browser to take a beating when rendering it on my implementation
* Taking this into consideration, a notification message alerting the user that the process is happening for when we're dealing with high numbers could be a good idea too
* Probably moving most or all the logic to render the data on the browser to a client-side level with some Javascript could result in important performance benefits
* Generating a text file with the table and return this file on the response could be an option which I have not explored for when numbers start to get too big to be displayed on the browser, and it could be a valid alternative or an improvement on the presentation level
* In terms of the prime numbers generation algorithm, upon some quick research there seem to be quite a few mathematical options to tackle this problem but very often they're presented in the form of "how to calculate all the existing prime numbers up to a given N number" (in which you know your search limit but do not know how many prime numbers you'll get) as opposed to how to calculate all the prime numbers up to the Nth prime (in which you know how many prime numbers you should get but do not know the limit you need to go to in order to get them), which is was this exercise required. Therefore, implementing algoriths like the well known Sieve of Eratosthenes, which seems to be very good at giving you all primes up to a N number, didn't quite fit the required scenario here.
* A challenge not properly addressed here is to test for "Primality" on each of the single prime numbers generated. I.e.: checking if any calculated prime number generated by the algorithm is really a true prime number. This would actually be a very good case for implementing a Sieve of Eratosthenes and test your prime numbers against it. My prime number generation algorith has only proven 100% reliablity for the first 500 known primes. I could have easily increased this number but I think that as a proof of concept testing the primality of the first 500 numbers was enough.
* On the mathematics of this exercise, I'm sure there must also be better implementations of algorights that would give you the first N prime numbers that would pass a string primality check. So there will always be room for improvement in that area too
* The navigation of the appligation is not ideal. Probably it would have been better to leave all presentation (data input and output) on the same page so you can re-run the functionality without having to go back from the results to the home page after every run
