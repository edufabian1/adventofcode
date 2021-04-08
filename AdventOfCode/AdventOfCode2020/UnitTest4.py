
inp = open('Resources/input4.txt').read().split('\n')
line = '\n'
count = 0
for k in range(0, len(inp), 1):
    if (inp[k] != '\n'):
        line += " " + str(inp[k])
    if (inp[k] == ''):
        if "byr:" in line and "iyr:" in line and "eyr:" in line and "hgt:" in line and "hcl:" in line and "ecl:" in line and "pid:" in line:
            count+=1
        line = '\n'
if "byr:" in line and "iyr:" in line and "eyr:" in line and "hgt:" in line and "hcl:" in line and "ecl:" in line and "pid:" in line:
    count+=1
print(count)