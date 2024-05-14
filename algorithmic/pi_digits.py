import math

def reverse_n_pi_digits(n: int) -> str:
    pi_digits = int(math.pi * math.pow(10, n - 1))
    return str(pi_digits)[::-1]
