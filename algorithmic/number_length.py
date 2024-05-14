from math import  log10

def num_len(number: int) -> str:
    return str((log10(number) + 1).__floor__())
