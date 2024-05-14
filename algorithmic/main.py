import number_length
import numbers_info
import pi_digits
import polindrom
import pythagorean_triplet

if __name__ == '__main__':
    print(number_length.num_len(100))
    for i in range(101):
        print(f"{i}: ")
        pythagorean_triplet.pythagorean_triplet_by_sum(i)
    print(polindrom.is_sorted_polyndrom("acbca"))
    numbers_info.show()
    print(pi_digits.reverse_n_pi_digits(5))
