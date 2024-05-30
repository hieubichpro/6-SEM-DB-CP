import matplotlib.pyplot as plt

# Данные для первого графика
x = [2, 10, 20, 30, 40, 50, 60, 70, 80, 90, 100]
y = [0.274000,1.513000,4.714000,11.359000,21.928000,45.710000,67.000000,125.247000,174.082000,200.249000,218.990000]

plt.plot(x, y)

plt.title("Зависимость времени составления турнирного расписания от количества команд")
plt.xlabel("Количество команд")
plt.ylabel("Время (мс)")
plt.show()