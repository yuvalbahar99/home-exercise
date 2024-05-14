import math
import statistics
import matplotlib.pyplot as plt
import numpy as np


def show() -> None:
    numbers = get_numbers()
    print(f"avg: {my_avg(numbers)}")
    print(f"positive numbers: {positive_amount(numbers)}")
    print(f"sorted numbers: {my_sort(numbers)}")
    graph(numbers)
    print((pearson_correlation(numbers)))


def get_numbers() -> list:
    numbers = []
    number = float_input("Number: ")
    while number != -1:
        numbers.append(number)
        number = float_input("Number: ")
    return numbers

def float_input(message: str) -> float:
    number = input(message)
    try:
        return float(number)
    except:
        return float_input(f"VALID {message}")

def my_avg(numbers: list) -> float:
    if len(numbers) == 0:
        return 0
    sum = 0
    for number in numbers:
        sum += number
    return sum / len(numbers)

def system_avg(numbers: list) -> float:
    return statistics.mean(numbers)

def positive_amount(numbers: list) -> int:
    count_positive = 0
    for number in numbers:
        if number > 0:
            count_positive += 1
    return count_positive

def system_sort(numbers: list) -> list:
    numbers_backup = numbers.copy()
    return numbers_backup.sort()

def my_sort(numbers: list) -> list:
    numbers_backup = numbers.copy()
    for number_index in range(len(numbers_backup) - 1):
        for number_index in range(len(numbers_backup) - 1):
            if numbers_backup[number_index] > numbers_backup[number_index + 1]:
                help_variable = numbers_backup[number_index]
                numbers_backup[number_index] = numbers_backup[number_index + 1]
                numbers_backup[number_index + 1] = help_variable
    return numbers_backup

def graph(numbers: list) -> None:
    xpoints = np.arange(1, len(numbers) + 1, 1)
    ypoints = np.array(numbers)
    plt.plot(xpoints, ypoints ,marker = 'o', linestyle = '')
    plt.title("Numbers Data")
    plt.xlabel("Input order")
    plt.ylabel("Number")
    plt.show()

def pearson_correlation(numbers: list) -> float:
    n = len(numbers)
    x_sum = 0
    x_square_sum = 0
    y_sum = 0
    y_square_sum = 0
    xy_sum = 0
    for i in range(0, n):
        x_sum += i + 1
        x_square_sum += (i + 1) ** 2
        y_sum += numbers[i]
        y_square_sum += numbers[i] ** 2
        xy_sum += (i + 1) * numbers[i]
    r = (n * xy_sum - x_sum * y_sum)\
        / (math.sqrt((n * x_square_sum - x_sum ** 2)
                   * (n * y_square_sum - y_sum ** 2)))
    return r
