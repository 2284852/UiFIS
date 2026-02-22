import tkinter as tk
from tkinter import ttk, messagebox, filedialog
import numpy as np
import matplotlib.pyplot as plt
from matplotlib.backends.backend_tkagg import FigureCanvasTkAgg
from matplotlib.figure import Figure
import pandas as pd
from datetime import datetime
import os
import json
from scipy import stats
from reportlab.lib.pagesizes import A4
from reportlab.pdfgen import canvas as pdf_canvas
from reportlab.pdfbase import pdfmetrics
from reportlab.pdfbase.ttfonts import TTFont

class QualityAnalysisApp:
    def __init__(self, root):
        self.root = root
        self.root.title("Анализ индексов качества процесса")
        self.root.geometry("1000x700")
        
        self.history_file = "quality_history.json"
        self.history = self.load_history()
        
        self.notebook = ttk.Notebook(root)
        self.notebook.pack(fill='both', expand=True, padx=10, pady=10)
        
        self.calculator_frame = ttk.Frame(self.notebook)
        self.notebook.add(self.calculator_frame, text='Калькулятор')
        self.create_calculator_tab()
        
        self.graph_frame = ttk.Frame(self.notebook)
        self.notebook.add(self.graph_frame, text='График распределения')
        self.create_graph_tab()
        
        self.history_frame = ttk.Frame(self.notebook)
        self.notebook.add(self.history_frame, text='История расчетов')
        self.create_history_tab()
        
        self.current_results = None
        
    def create_calculator_tab(self):
        input_frame = ttk.LabelFrame(self.calculator_frame, text="Параметры процесса", padding=10)
        input_frame.pack(fill='x', padx=10, pady=10)
        
        ttk.Label(input_frame, text="Верхняя граница допуска (USL):").grid(row=0, column=0, sticky='w', pady=5)
        self.usl_var = tk.StringVar()
        ttk.Entry(input_frame, textvariable=self.usl_var, width=20).grid(row=0, column=1, padx=5, pady=5)
        
        ttk.Label(input_frame, text="Нижняя граница допуска (LSL):").grid(row=1, column=0, sticky='w', pady=5)
        self.lsl_var = tk.StringVar()
        ttk.Entry(input_frame, textvariable=self.lsl_var, width=20).grid(row=1, column=1, padx=5, pady=5)
        
        ttk.Label(input_frame, text="Среднее значение (μ):").grid(row=2, column=0, sticky='w', pady=5)
        self.mean_var = tk.StringVar()
        ttk.Entry(input_frame, textvariable=self.mean_var, width=20).grid(row=2, column=1, padx=5, pady=5)
        
        ttk.Label(input_frame, text="Стандартное отклонение (σ):").grid(row=3, column=0, sticky='w', pady=5)
        self.std_var = tk.StringVar()
        ttk.Entry(input_frame, textvariable=self.std_var, width=20).grid(row=3, column=1, padx=5, pady=5)
        
        btn_frame = ttk.Frame(input_frame)
        btn_frame.grid(row=4, column=0, columnspan=2, pady=10)
        
        ttk.Button(btn_frame, text="Рассчитать", command=self.calculate_indices).pack(side='left', padx=5)
        ttk.Button(btn_frame, text="Сохранить в историю", command=self.save_to_history).pack(side='left', padx=5)
        ttk.Button(btn_frame, text="Экспорт в Excel", command=self.export_to_excel).pack(side='left', padx=5)
        ttk.Button(btn_frame, text="Экспорт в PDF", command=self.export_to_pdf).pack(side='left', padx=5)
        
        result_frame = ttk.LabelFrame(self.calculator_frame, text="Результаты расчета", padding=10)
        result_frame.pack(fill='both', expand=True, padx=10, pady=10)
        
        ttk.Label(result_frame, text="Индекс воспроизводимости (Cp):", font=('Arial', 10, 'bold')).grid(row=0, column=0, sticky='w', pady=5)
        self.cp_var = tk.StringVar()
        self.cp_label = ttk.Label(result_frame, textvariable=self.cp_var, font=('Arial', 12))
        self.cp_label.grid(row=0, column=1, sticky='w', padx=10, pady=5)
        
        ttk.Label(result_frame, text="Индекс пригодности (Cpk):", font=('Arial', 10, 'bold')).grid(row=1, column=0, sticky='w', pady=5)
        self.cpk_var = tk.StringVar()
        self.cpk_label = ttk.Label(result_frame, textvariable=self.cpk_var, font=('Arial', 12))
        self.cpk_label.grid(row=1, column=1, sticky='w', padx=10, pady=5)
        
        ttk.Label(result_frame, text="Интерпретация:", font=('Arial', 10, 'bold')).grid(row=2, column=0, sticky='w', pady=5)
        self.interpretation_var = tk.StringVar()
        self.interpretation_label = ttk.Label(result_frame, textvariable=self.interpretation_var, font=('Arial', 11))
        self.interpretation_label.grid(row=2, column=1, sticky='w', padx=10, pady=5)
        
        ttk.Label(result_frame, text="Статус процесса:", font=('Arial', 10, 'bold')).grid(row=3, column=0, sticky='w', pady=5)
        self.status_var = tk.StringVar()
        self.status_label = ttk.Label(result_frame, textvariable=self.status_var, font=('Arial', 11, 'bold'))
        self.status_label.grid(row=3, column=1, sticky='w', padx=10, pady=5)
        
    def create_graph_tab(self):
        graph_container = ttk.Frame(self.graph_frame)
        graph_container.pack(fill='both', expand=True, padx=10, pady=10)
        
        self.fig = Figure(figsize=(8, 6), dpi=100)
        self.ax = self.fig.add_subplot(111)
        
        self.canvas = FigureCanvasTkAgg(self.fig, master=graph_container)
        self.canvas.get_tk_widget().pack(fill='both', expand=True)
        
        ttk.Button(graph_container, text="Обновить график", command=self.update_graph).pack(pady=10)
        
    def create_history_tab(self):
        table_frame = ttk.Frame(self.history_frame)
        table_frame.pack(fill='both', expand=True, padx=10, pady=10)
        
        columns = ('Дата', 'USL', 'LSL', 'Среднее', 'σ', 'Cp', 'Cpk', 'Статус')
        self.history_tree = ttk.Treeview(table_frame, columns=columns, show='headings', height=15)
        
        for col in columns:
            self.history_tree.heading(col, text=col)
            self.history_tree.column(col, width=100)
        
        scrollbar = ttk.Scrollbar(table_frame, orient=tk.VERTICAL, command=self.history_tree.yview)
        self.history_tree.configure(yscrollcommand=scrollbar.set)
        
        self.history_tree.pack(side='left', fill='both', expand=True)
        scrollbar.pack(side='right', fill='y')
        
        btn_frame = ttk.Frame(self.history_frame)
        btn_frame.pack(fill='x', padx=10, pady=10)
        
        ttk.Button(btn_frame, text="Загрузить расчет", command=self.load_calculation).pack(side='left', padx=5)
        ttk.Button(btn_frame, text="Очистить историю", command=self.clear_history).pack(side='left', padx=5)
        ttk.Button(btn_frame, text="Экспорт истории в Excel", command=self.export_history_to_excel).pack(side='left', padx=5)
        
        self.refresh_history_table()
        
    def calculate_indices(self):
        try:
            usl = float(self.usl_var.get())
            lsl = float(self.lsl_var.get())
            mean = float(self.mean_var.get())
            std = float(self.std_var.get())
            
            if std <= 0:
                messagebox.showerror("Ошибка", "Стандартное отклонение должно быть больше 0")
                return
            
            if usl <= lsl:
                messagebox.showerror("Ошибка", "USL должен быть больше LSL")
                return
            
            cp = (usl - lsl) / (6 * std)
            
            cpu = (usl - mean) / (3 * std)
            cpl = (mean - lsl) / (3 * std)
            cpk = min(cpu, cpl)
            
            interpretation, status, color = self.interpret_cp_cpk(cpk)
            
            self.cp_var.set(f"{cp:.3f}")
            self.cpk_var.set(f"{cpk:.3f}")
            self.interpretation_var.set(interpretation)
            self.status_var.set(status)
            
            self.cp_label.configure(foreground=color)
            self.cpk_label.configure(foreground=color)
            self.status_label.configure(foreground=color)
            
            self.current_results = {
                'date': datetime.now().strftime("%Y-%m-%d %H:%M:%S"),
                'usl': usl,
                'lsl': lsl,
                'mean': mean,
                'std': std,
                'cp': cp,
                'cpk': cpk,
                'interpretation': interpretation,
                'status': status
            }
            
            messagebox.showinfo("Успех", "Расчет выполнен успешно!")
            
        except ValueError:
            messagebox.showerror("Ошибка", "Пожалуйста, введите корректные числовые значения")
            
    def interpret_cp_cpk(self, value):
        if value >= 1.33:
            return "Отличная воспроизводимость (процесс пригоден)", "Отлично", "green"
        elif value >= 1.0:
            return "Удовлетворительная воспроизводимость (требуется контроль)", "Удовлетворительно", "blue"
        elif value >= 0.67:
            return "Неудовлетворительная воспроизводимость (требуется улучшение)", "Неудовлетворительно", "orange"
        else:
            return "Критическая воспроизводимость (процесс непригоден)", "Критично", "red"
        
    def update_graph(self):
        if self.current_results is None:
            messagebox.showwarning("Предупреждение", "Сначала выполните расчет на вкладке Калькулятор")
            return
        
        self.ax.clear()
        
        usl = self.current_results['usl']
        lsl = self.current_results['lsl']
        mean = self.current_results['mean']
        std = self.current_results['std']
        
        x = np.linspace(lsl - 3*std, usl + 3*std, 1000)
        y = stats.norm.pdf(x, mean, std)
        
        self.ax.plot(x, y, 'b-', linewidth=2, label='Распределение процесса')
        
        x_in = np.linspace(lsl, usl, 1000)
        y_in = stats.norm.pdf(x_in, mean, std)
        self.ax.fill_between(x_in, y_in, alpha=0.3, color='green', label='В допуске')
        
        x_left = np.linspace(lsl - 3*std, lsl, 1000)
        y_left = stats.norm.pdf(x_left, mean, std)
        self.ax.fill_between(x_left, y_left, alpha=0.3, color='red', label='Брак (ниже LSL)')
        
        x_right = np.linspace(usl, usl + 3*std, 1000)
        y_right = stats.norm.pdf(x_right, mean, std)
        self.ax.fill_between(x_right, y_right, alpha=0.3, color='red', label='Брак (выше USL)')
        
        self.ax.axvline(x=lsl, color='r', linestyle='--', linewidth=2, label=f'LSL = {lsl}')
        self.ax.axvline(x=usl, color='r', linestyle='--', linewidth=2, label=f'USL = {usl}')
        
        self.ax.axvline(x=mean, color='g', linestyle='-', linewidth=2, label=f'Среднее = {mean}')
        
        self.ax.set_xlabel('Значение параметра', fontsize=12)
        self.ax.set_ylabel('Плотность вероятности', fontsize=12)
        self.ax.set_title(f'Распределение процесса\nCp = {self.current_results["cp"]:.3f}, Cpk = {self.current_results["cpk"]:.3f}', 
                         fontsize=14, fontweight='bold')
        self.ax.legend(loc='best')
        self.ax.grid(True, alpha=0.3)
        
        self.canvas.draw()
        
    def save_to_history(self):
        if self.current_results is None:
            messagebox.showwarning("Предупреждение", "Нет данных для сохранения. Выполните расчет.")
            return
        
        self.history.append(self.current_results)
        self.save_history()
        self.refresh_history_table()
        messagebox.showinfo("Успех", "Расчет сохранен в историю")
        
    def load_history(self):
        if os.path.exists(self.history_file):
            try:
                with open(self.history_file, 'r', encoding='utf-8') as f:
                    return json.load(f)
            except:
                return []
        return []
    
    def save_history(self):
        with open(self.history_file, 'w', encoding='utf-8') as f:
            json.dump(self.history, f, ensure_ascii=False, indent=2)
            
    def refresh_history_table(self):
        for item in self.history_tree.get_children():
            self.history_tree.delete(item)
        
        for record in reversed(self.history):
            self.history_tree.insert('', 'end', values=(
                record['date'],
                f"{record['usl']:.3f}",
                f"{record['lsl']:.3f}",
                f"{record['mean']:.3f}",
                f"{record['std']:.3f}",
                f"{record['cp']:.3f}",
                f"{record['cpk']:.3f}",
                record['status']
            ))
            
    def load_calculation(self):
        selected = self.history_tree.selection()
        if not selected:
            messagebox.showwarning("Предупреждение", "Выберите расчет из таблицы")
            return
        
        item = self.history_tree.item(selected[0])
        values = item['values']
        
        self.usl_var.set(values[1])
        self.lsl_var.set(values[2])
        self.mean_var.set(values[3])
        self.std_var.set(values[4])
        
        self.notebook.select(0)
        
        self.calculate_indices()
        
    def clear_history(self):
        if messagebox.askyesno("Подтверждение", "Вы уверены, что хотите очистить всю историю?"):
            self.history = []
            self.save_history()
            self.refresh_history_table()
            messagebox.showinfo("Успех", "История очищена")
            
    def export_to_excel(self):
        if self.current_results is None:
            messagebox.showwarning("Предупреждение", "Нет данных для экспорта")
            return
        
        file_path = filedialog.asksaveasfilename(
            defaultextension=".xlsx",
            filetypes=[("Excel files", "*.xlsx"), ("All files", "*.*")],
            initialfile=f"quality_report_{datetime.now().strftime('%Y%m%d_%H%M%S')}.xlsx"
        )
        
        if file_path:
            try:
                df = pd.DataFrame([self.current_results])
                df.to_excel(file_path, index=False, engine='openpyxl')
                messagebox.showinfo("Успех", f"Данные экспортированы в {file_path}")
            except Exception as e:
                messagebox.showerror("Ошибка", f"Ошибка при экспорте: {str(e)}")
                
    def export_history_to_excel(self):
        if not self.history:
            messagebox.showwarning("Предупреждение", "История пуста")
            return
        
        file_path = filedialog.asksaveasfilename(
            defaultextension=".xlsx",
            filetypes=[("Excel files", "*.xlsx"), ("All files", "*.*")],
            initialfile=f"quality_history_{datetime.now().strftime('%Y%m%d_%H%M%S')}.xlsx"
        )
        
        if file_path:
            try:
                df = pd.DataFrame(self.history)
                df.to_excel(file_path, index=False, engine='openpyxl')
                messagebox.showinfo("Успех", f"История экспортирована в {file_path}")
            except Exception as e:
                messagebox.showerror("Ошибка", f"Ошибка при экспорте: {str(e)}")
                
    def export_to_pdf(self):
        if self.current_results is None:
            messagebox.showwarning("Предупреждение", "Нет данных для экспорта")
            return
        
        file_path = filedialog.asksaveasfilename(
            defaultextension=".pdf",
            filetypes=[("PDF files", "*.pdf"), ("All files", "*.*")],
            initialfile=f"quality_report_{datetime.now().strftime('%Y%m%d_%H%M%S')}.pdf"
        )
        
        if file_path:
            try:
                c = pdf_canvas.Canvas(file_path, pagesize=A4)
                width, height = A4
                
                c.setFont("Helvetica-Bold", 16)
                c.drawString(50, height - 50, "ОТЧЕТ ПО АНАЛИЗУ КАЧЕСТВА ПРОЦЕССА")
                
                c.setFont("Helvetica", 10)
                c.drawString(50, height - 80, f"Дата: {self.current_results['date']}")
                
                c.setFont("Helvetica-Bold", 12)
                c.drawString(50, height - 110, "ПАРАМЕТРЫ ПРОЦЕССА:")
                
                c.setFont("Helvetica", 10)
                y_pos = height - 130
                c.drawString(70, y_pos, f"Верхняя граница допуска (USL): {self.current_results['usl']:.3f}")
                y_pos -= 20
                c.drawString(70, y_pos, f"Нижняя граница допуска (LSL): {self.current_results['lsl']:.3f}")
                y_pos -= 20
                c.drawString(70, y_pos, f"Среднее значение (μ): {self.current_results['mean']:.3f}")
                y_pos -= 20
                c.drawString(70, y_pos, f"Стандартное отклонение (σ): {self.current_results['std']:.3f}")
                
                y_pos -= 30
                c.setFont("Helvetica-Bold", 12)
                c.drawString(50, y_pos, "РЕЗУЛЬТАТЫ РАСЧЕТА:")
                
                c.setFont("Helvetica", 10)
                y_pos -= 20
                c.drawString(70, y_pos, f"Индекс воспроизводимости (Cp): {self.current_results['cp']:.3f}")
                y_pos -= 20
                c.drawString(70, y_pos, f"Индекс пригодности (Cpk): {self.current_results['cpk']:.3f}")
                
                y_pos -= 30
                c.setFont("Helvetica-Bold", 12)
                c.drawString(50, y_pos, "ИНТЕРПРЕТАЦИЯ:")
                
                c.setFont("Helvetica", 10)
                y_pos -= 20
                c.drawString(70, y_pos, self.current_results['interpretation'])
                y_pos -= 20
                c.drawString(70, y_pos, f"Статус процесса: {self.current_results['status']}")
                
                c.save()
                messagebox.showinfo("Успех", f"Отчет сохранен в {file_path}")
            except Exception as e:
                messagebox.showerror("Ошибка", f"Ошибка при экспорте: {str(e)}")

def main():
    root = tk.Tk()
    app = QualityAnalysisApp(root)
    root.mainloop()

if __name__ == "__main__":
    main()