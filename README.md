# Source code for my bachelor thesis prject : solving Sudoku puzzle using evolutionary algorithms

This project was my final project, the goal was to solve a sudoku puzzle. The method I used here was genetic algorithms and simulated annealing.
The first algorithm put numbers in free houses in a way that satisfy unique number in an area role.The fitness value here is the sum of all missed number in each row and column.
Next, I choose 50 answer between 100 random answers created which has better fitness value.
Then I choose two of the best answers in 50 answers and crossover first areas to check if fitness number improves. If so I keep the change if not I turn the change and this action continue for all 9 areas of 50 answers to get half best answers and  25 worst answers thrown away. The algorithm repeats for rest 49 answers until remains 25 best answers.
Next step is to improve fitness value by swapping the values of each row and column to check if fitness gets better in a way that doesn't break the unique number in each row rule . The last step is to replace this 25 best answers with the worst 25 answers of the initial 100 answers.
continuing this method gets us a single solution with fitness 0 which is the correct answer
