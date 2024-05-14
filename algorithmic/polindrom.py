
def is_sorted_polyndrom(text: str) -> bool:
    if len(text) < 2:
        return True
    first_half = text[:(len(text) / 2).__ceil__()]
    oposite_second_half = text[:(len(text) / 2).__floor__() - 1:-1]
    if first_half != oposite_second_half:
        return False
    for letter_index in range(len(first_half) - 1):
        if first_half[letter_index] > first_half[letter_index + 1]:
            return False
    return True
