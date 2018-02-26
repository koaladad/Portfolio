import os
from random import *

def ask_question(data_array):
	random_var = randrange(0,len(data_array))
	question = data_array[random_var][0]
	answer = data_array[random_var][1]

	input_value = raw_input((question))

	#hi
	#Correct Answer
	if (input_value == answer):
		print ("CORRECT.")
		return True
	else:
		print("WRONG. The correct answer is " + answer + ".")
		return False

def clear_screen():
	os.system('cls')

def wait_to_continue():
	os.system("pause")		


file_name = raw_input("Enter text file name:")

q_list = []
counter = 0

with open(file_name) as file:
	for line in file:
		#line = line.encode('windows-1252').decode('utf-8-sig')
		(key, value) = line.split('-')
		list2 = []
		list2.append(key)
		list2.append(value.rstrip())
		q_list.append(list2)
		counter += 1

#print (q_list)

question_count = None

while question_count is None:
	input_value = raw_input("Enter # of questions: ")

	try:
		# try to convert the string input to number
		question_count = int(input_value)

	except ValueError:
		# tells the user off
		print("Not a number. Enter a number only.")

number_correct = 0
os.system('cls')

#question count = number of questions to ask
for i in range(question_count):
	print("***** QUESTION " + repr(i+1) + " *****")

	if (i != 0):
		percent_score = round(((number_correct/(i)) * 100),2)
		print("* " + repr(number_correct) +" OUT OF "+ repr(i) + "  " + repr(percent_score) + "% *")

	is_correct = ask_question(q_list)

	if (is_correct):
		number_correct += 1

	print(" ")
	wait_to_continue()
	clear_screen()

	if (i == question_count-1):
		percent_score = round(((number_correct/(i+1)) * 100),2)
		print("*****FINAL SCORE******")
		print("   " + repr(number_correct) +" OUT OF "+ repr(i+1) + " - " + repr(percent_score) + "%")
	

