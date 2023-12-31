import time 
import threading
import tkinter as tk
from tkinter import ttk
from tkinter import ttk, PhotoImage

class pomodoro:

    def __init__(self):
        self.root = tk.Tk()
        self.root.geometry("600x300")
        self.root.title("Scarlet Hawk Pomodoro Timer")
        self.root.tk.call('wm', 'iconphoto', self.root._w, PhotoImage(file='icon.png')) 

        self.s = ttk.Style()
        self.s.configure("TNotebook.tab", font=('Helvetica', '11', 'bold'))
        self.s.configure("TButton", font=('Helvetica', '11', 'bold'))

        self.tabs = ttk.Notebook(self.root)
        self.tabs.pack(fill="both", pady=10, expand=True)

        self.tab1 = ttk.Frame(self.tabs, width=600, height=100)
        self.tab2 = ttk.Frame(self.tabs, width=600, height=100)
        self.tab3 = ttk.Frame(self.tabs, width=600, height=100)
   
        self.pomodoro_label = ttk.Label(self.tab1, text="25:00", font=('Helvetica', '18', 'bold'))
        self.pomodoro_label.pack(pady=20)

        self.shortbreak_label = ttk.Label(self.tab2, text="05:00", font=('Helvetica', '18', 'bold'))
        self.shortbreak_label.pack(pady=20)

        self.longbreak_label = ttk.Label(self.tab3, text="15:00", font=('Helvetica', '18', 'bold'))
        self.longbreak_label.pack(pady=20)


        self.tabs.add(self.tab1, text="Pomodoro")
        self.tabs.add(self.tab2, text="Short Break")
        self.tabs.add(self.tab3, text="Long Break")

        self.grid_layout = ttk.Frame(self.root)
        self.grid_layout.pack(pady=10)

        self.start_button = ttk.Button(self.grid_layout, text="Start", command=self.timer_start_thread)
        self.start_button.grid(row=0, column=0)

        self.skip_button = ttk.Button(self.grid_layout, text="Skip", command=self.clock_skip)
        self.skip_button.grid(row=0, column=1)

        self.reset_button = ttk.Button(self.grid_layout, text="Reset", command=self.clock_reset)
        self.reset_button.grid(row=0, column=2)

        self.pomodoro_counter_label = ttk.Label(self.grid_layout, text="Pomodoros Completed: 0", font=('Helvetica', '11', 'bold'))
        self.pomodoro_counter_label.grid(row=1, column=0, columnspan=3, pady=10)

        self.pomodoros = 0
        self.skipped = False
        self.stopped = False
        self.running = False

        self.root.mainloop()

    def timer_start(self):
        self.stopped = False
        self.skipped = False
        timer_id = self.tabs.index(self.tabs.select()) + 1
        
        if timer_id == 1:
            full_seconds = 60 * 25  # 1500
            while full_seconds > 0 and not self.stopped:
                minutes, seconds = divmod(full_seconds, 60)
                self.pomodoro_label.configure(text=f"{minutes:02d}:{seconds:02d}")
                self.root.update()
                time.sleep(1)
                full_seconds -= 1
            if not self.stopped or self.skipped:
                self.pomodoros += 1
                self.pomodoro_counter_label.configure(text=f"Pomodoros Completed: {self.pomodoros}")
                if self.pomodoros % 4 == 0:
                    self.tabs.select(2)
                else:
                    self.tabs.select(1)
                self.start_timer()
        elif timer_id == 2:
            full_seconds = 60 * 5  # 300
            while full_seconds > 0 and not self.stopped:
                minutes, seconds = divmod(full_seconds, 60)
                self.pomodoro_label.configure(text=f"{minutes:02d}:{seconds:02d}")
                self.root.update()
                time.sleep(1)
                full_seconds -= 1
            if not self.stopped or self.skipped:
                self.tabs.select(0)
                self.start_timer()
        elif timer_id == 3:
            full_seconds = 60 * 15  # 900
            while full_seconds > 0 and not self.stopped:
                minutes, seconds = divmod(full_seconds, 60)
                self.pomodoro_label.configure(text=f"{minutes:02d}:{seconds:02d}")
                self.root.update()
                time.sleep(1)
                full_seconds -= 1
            if not self.stopped or self.skipped:
                self.tabs.select(0)
                self.start_timer()
        else:
            print("Timer ID is invalid")

    def timer_start_thread(self):
        if not self.running:
            t = threading.Thread(target=self.timer_start)
            t.start()
            self.running = True

    def clock_reset(self):
        self.stopped = True
        self.skipped = False
        self.pomodoros = 0
        self.pomodoro_label.config(text="25:00")
        self.shortbreak_label.config(text="05:00")
        self.longbreak_label.config(text="15:00")
        self.pomodoro_counter_label.config(text="Pomodoros Completed: 0")
        self.running = False

    def clock_skip(self):
        current_tab = self.tabs.index(self.tabs.select())
        if current_tab == 0:
            self.pomodoro_label.config(text="25:00")
        elif current_tab == 1:
            self.shortbreak_label.config(text="05:00")
        elif current_tab == 2:
            self.longbreak_label.config(text="15:00")
        self.skipped = True
        self.stopped = True

pomodoro()