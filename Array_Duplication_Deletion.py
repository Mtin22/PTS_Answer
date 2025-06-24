def duplicated_func():
    duplicated_array=["bread", "bread", "peas", "mustard", "peas", "ketchup", "mayo", "water", "ketchup"]
    seen_words=set()
    for rlength in range(len(duplicated_array)-1,-1,-1):
        if duplicated_array[rlength] in seen_words:
            del duplicated_array[rlength]
        else:
            seen_words.add(duplicated_array[rlength])
    return duplicated_array

print(duplicated_func())