import math


def pythagorean_triplet_by_sum(sum: int) -> None:
    for a in range(1, int(sum / 3)):
        for b in range(a + 1,
                       ((sum - a) / 2).__ceil__()):
            c = math.sqrt(a ** 2 + b ** 2)
            if a + b + c == sum:
                print(f"{a} < {b} < "
                      f"{int(math.sqrt(a ** 2 + b ** 2))}")
