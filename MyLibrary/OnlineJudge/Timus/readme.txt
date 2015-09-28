1005. Stone Pile
Time limit: 1.0 second
Memory limit: 64 MB
You have a number of stones with known weights w1, …, wn. Write a program that will rearrange the stones into two piles such that weight difference between the piles is minimal.
Input
Input contains the number of stones n (1 ≤ n ≤ 20) and weights of the stones w1, …, wn (integers, 1 ≤ wi ≤ 100000) delimited by white spaces.
Output
Your program should output a number representing the minimal possible weight difference between stone piles.
Sample
input	output
5
5 8 13 27 14
3
Problem Source: USU Championship 1997


1068. Sum
Time limit: 2.0 second
Memory limit: 64 MB
Your task is to find the sum of all integer numbers lying between 1 and N inclusive.
Input
The input consists of a single integer N that is not greater than 10000 by it's absolute value.
Output
Write a single integer number that is the sum of all integer numbers lying between 1 and N inclusive.
Sample
input	output
-3
-5
Problem Source: 2000-2001 ACM Northeastern European Regional Programming Contest (test tour)


1209. 1, 10, 100, 1000...
Time limit: 1.0 second
Memory limit: 64 MB
Let's consider an infinite sequence of digits constructed of ascending powers of 10 written one after another. Here is the beginning of the sequence: 110100100010000… You are to find out what digit is located at the definite position of the sequence.
Input
There is the only integer N in the first line (1 ≤ N ≤ 65535). The i-th of N left lines contains the integer Ki — the number of position in the sequence (1 ≤ Ki ≤ 231 − 1).
Output
You are to output N digits 0 or 1 separated with a space. More precisely, the i-th digit of output is to be equal to the Ki-th digit of described above sequence.
Sample
input	output

4
3
14
7
6

0 0 1 0

Problem Author: Alexey Lakhtin
Problem Source: USU Open Collegiate Programming Contest October'2002 Junior Session


1086. Cryptography
Time limit: 2.0 second
Memory limit: 64 MB
While preparing this problem set the jury has run into the following problem: it was necessary to send by e-mail the texts of the problems. As it is well known, e-mail is not reliable, messages are sent not enciphered, there is a danger that someone can intercept them. The members of the program committee wanted no participant know the texts of the problems before the start of the contest. That's why they resorted to cryptography methods in order to save the texts of the problems from an unsanctioned reading. The jury gas worked up a new way of enciphering of a text. It is not patented yet, so it's kept secret. However, we'll reveal you one secret: the new algorithm is based on the work with prime numbers. In particular, in uses a calculation of n-th by order prime number.
Several members of the program committee independently have worked up programs that make such calculations, but these programs produce different answers. Each one of the programmers is sure that his program works correctly. That's why the jury has reached the deadlock and can't continue working. The contest is about not to take place.
You are to help to the jury and to save the contest. We want you to write a program that calculates the n-th by order prime number. The main thing is that your program should work correctly.
Input
First line contains a positive integer k. Then k positive integers follow (one in each line). The numbers don't exceed 15000.
Output
For each number n you should output the n-th by order prime number. Each number should be in its line.
Sample
input	output

4
3
2
5
7

	

5
3
11
17

Notes
The prime number is a positive integer that has exactly two different positive divisors, i.e. 1 is not a prime number.
Problem Author: folklore
Problem Source: The 3rd high school children programming contest, USU, Yekaterinburg, Russia, March 4, 2001


1083. Factorials!!!
Time limit: 1.0 second
Memory limit: 64 MB
Definition 1. n!!…! = n(n−k)(n−2k)…(n mod k), if k doesn’t divide n; n!!…! = n(n−k)(n−2k)…k, if k divides n (There are k marks ! in the both cases).
Definition 2. X mod Y — a remainder after division of X by Y.
For example, 10 mod 3 = 1; 3! = 3·2·1; 10!!! = 10·7·4·1.
Given numbers n and k we have calculated a value of the expression in the first definition. Can you do it as well?
Input
contains the only line: one integer n, 1 ≤ n ≤ 10, then exactly one space, then k exclamation marks, 1 ≤ k ≤ 20.
Output
contains one number — n!!…! (there are k marks ! here).
Sample
input	output
9 !!
945
Problem Author: Oleg Katz 
Problem Source: The 3rd high school children programming contest, USU, Yekaterinburg, Russia, March 4, 2001


1197. Lonesome Knight
Time limit: 1.0 second
Memory limit: 64 MB
The statement of this problem is very simple: you are to determine how many squares of the chessboard can be attacked by a knight standing alone on the board. Recall that a knight moves two squares forward (horizontally or vertically in any direction) and then one square sideways (perpedicularly to the first direction).
Input
The first line contains the number N of test cases, 1 ≤ N ≤ 100. Each of the following N lines contains a test: two characters. The first character is a lowercase English letter from 'a' to 'h' and the second character is an integer from 1 to 8; they specify the rank and file of the square at which the knight is standing.
Output
Output N lines. Each line should contain the number of the squares of the chessboard that are under attack by the knight.
Sample
input	output
3
a1
d4
g6
2
8
6
Problem Author: folklore
Problem Source: Fifth High School Children Programming Contest, Ekaterinburg, March 02, 2002



1014. Product of Digits
Time limit: 1.0 second
Memory limit: 64 MB
Your task is to find the minimal positive integer number Q so that the product of digits of Q is exactly equal to N.
Input
The input contains the single integer number N (0 ≤ N ≤ 109).
Output
Your program should print to the output the only number Q. If such a number does not exist print −1.
Sample
input	output
10
25
Problem Source: Ural State University Internal Contest '99 #2



1313. Some Words about Sport
Time limit: 0.5 second
Memory limit: 64 MB
Ural doctors worry about the health of their youth very much. Special investigations showed that a lot of clever students instead of playing football, skating or bicycling had participated in something like Programming Olympiads. Moreover, they call it sports programming! To sit near the monitor and think during 5 hours a day – is it a sport? To do it two times per year during the contests – it is more or less normal, but during the preparations to the nearest contest they spend several hours a week sitting at their computers! It would be possible to understand if they were some blockheads and dunces, but they are ones of the best students all over the world!
To save students from the harmful habit to sit at the computer for hours, Ural doctors has invented a fundamentally new monitor with diagonal trace of a beam in its electron-beam tube. Soon the winners of Ural Programming Championship would be awarded with such monitors. In the specially designed square monitor the electronic beam would scan the screen not horizontally but diagonally. The difference of the lengths of different diagonals causes such effects as non-uniform brightness, flashing and non-linear distortions. The terrible properties of such monitors would break of the habit of looking at the monitor for hours. There is a little problem: the majority of computer video cards generates the normal “rectangle” signal for monitor. So it is necessary to develop special adapter-program, which should transform the usual “rectangle” signal to the signal necessary for this kind of monitors. Program should be fast and reliable. That’s why the development of this program is entrusted to the participants of the Ural Championship for Sports Programming.
Input
The first input line contains the single integer N (1 ≤ N ≤ 100) – the number of pixels on the side of new square monitor. It is followed by N lines, each containing N positive integers not exceeding 100 divided by spaces. It is the image outputting by the usual video card (as you can see the color depth of new monitor is not so large – anyway usual programmer does not need more than 100 colors).
Output
You are to write the program that outputs the sequence for input into the new monitor. Pixels are numbered from the upper-left corner of the screen diagonally from left ot right and bottom-up. There is no need to explain details – look at the sample and you'll understand everything.
Sample
input	output

4
1 3 6 10
2 5 9 13
4 8 12 15
7 11 14 16

	

1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16

Problem Author: Idea - Stanislav Vasilyev, prepared by Stanislav Vasilyev and Alexander Klepinin
Problem Source: VIII Collegiate Students Urals Programming Contest. Yekaterinburg, March 11-16, 2004


1044. Lucky Tickets. Easy!
Time limit: 2.0 second
Memory limit: 64 MB
Background
The public transport administration of Ekaterinburg is anxious about the fact that passengers don’t like to pay for passage doing their best to avoid the fee. All the measures that had been taken (hard currency premiums for all of the chiefs, increase in conductors’ salaries, reduction of number of buses) were in vain. An advisor especially invited from the Ural State University says that personally he doesn’t buy tickets because he rarely comes across the lucky ones (a ticket is lucky if the sum of the first three digits in its number equals to the sum of the last three ones). So, the way out is found — of course, tickets must be numbered in sequence, but the number of digits on a ticket may be changed. Say, if there were only two digits, there would have been ten lucky tickets (with numbers 00, 11, …, 99). Maybe under the circumstances the ratio of the lucky tickets to the common ones is greater? And what if we take four digits? A huge work has brought the long-awaited result: in this case there will be 670 lucky tickets. But what to do if there are six or more digits?
Problem
So you are to save public transport of our city. Write a program that determines a number of lucky tickets for the given number of digits. By the way, there can’t be more than nine digits on one ticket.
Input
contains a positive even integer not greater than 9.
Output
should contain a number of tickets such that the sum of the first half of digits is equal to the sum of the second half of digits.
Sample
input	output

4

	

670

Problem Author: Stanislav Vasilyev
Problem Source: Ural State University Internal Contest October'2000 Students Session



1079. Maximum
Time limit: 2.0 second
Memory limit: 64 MB
Consider the sequence of numbers ai, i = 0, 1, 2, …, which satisfies the following requirements:

    a0 = 0
    a1 = 1
    a2i = ai
    a2i+1 = ai + ai+1

for every i = 1, 2, 3, … .
Write a program which for a given value of n finds the largest number among the numbers a0, a1, …, an.
Input
You are given several test cases (not more than 10). Each test case is a line containing an integer n (1 ≤ n ≤ 99 999). The last line of input contains 0.
Output
For every n in the input write the corresponding maximum value found.
Sample
input	output

5
10
0

	

3
4

Problem Author: Emil Kelevedzhiev
Problem Source: Winter Mathematical Festival Varna '2001 Informatics Tournament



1319. Hotel
Time limit: 1.0 second
Memory limit: 64 MB
Problem illustration
— You programmers are lucky! You don't have to deal with these terrible people – designers… This story happened with me not so long ago. We had an order from a company building a new hotel. One day they brought a sketch to our workshop. They said that THIS was invented by a very cool designer. They said they had paid heaps of money for THIS. So, THIS had to be built. In general, THIS was not a very complex thing. It was just a square set of shelves where a porter puts guests' mail. Usual hotels have usual stands with shelves for this purpose. But this cool designer had turned everything upside down! To be more precise, not exactly upside down, but upon a corner. Moreover, the cells should be numbered from the right to the left, from the top to the bottom, looking at THIS, staying on its corner, of course. Tell me please, how can the master attach the labels with numbers to THIS? He will look on the shelves, staying normally on its side, you know. He will get tangled on the fourth label already! I will get tangled on the seventh, myself… Actually one should make such designers to label the shelves themselves.
— Oh! You are the cool programmer, I know. Couldn’t you help me? I need just a printout of the table with an arrangement of the labels in the cells. But not in such way as THIS will hang on the wall, but as THIS stands on the table of my workshop. Yes, I understand that you are busy, but you are busy every time! Preparations to the Ural Championship, tests, solutions… So what? If you can’t do it yourself – entrust your competitors with this task. They are the best programmers all over the world, aren’t they? I don’t believe that they couldn’t print the desired table having the size of the square! I would never believe it! So… Excellent! I will take the desired printout away after the contest.
Input
The input consists of the only one integer N (1 ≤ N ≤ 100), which is the size of the square.
Output
You are to write a program that outputs the table of numbers, as they would be arranged when THIS would stand in the workshop. The label with number 1 should be in the upper right corner and other numbers should be arranged along the diagonals from the top to the bottom. The label with the last number (N*N) should be in the lower left corner.
Sample
input	output

3

	

4 2 1
7 5 3
9 8 6

Problem Author: Stanislav Vasilyev
Problem Source: VIII Collegiate Students Urals Programming Contest. Yekaterinburg, March 11-16, 2004



