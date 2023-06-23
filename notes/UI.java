package notes;

import java.awt.Font;
import java.awt.event.*;
import javax.swing.*;

public class UI 
{
    public static final Integer FONT_SIZES[] = {4, 8, 10, 12, 14, 16, 18, 20, 24, 28, 32, 40, 48, 72};
    public static final String FONT_NAMES[] = {"Monospaced", "SansSerif", "Serif", "Dialog", "DialogInput"};

    private Note note;

    public UI(Note note)
    {
        this.note = note;

        JFrame frame = new JFrame("Note");
        frame.setSize(400, 400);

        JButton bolden = new JButton("Bold");
        bolden.setBounds(50, 100, 95, 30);
        bolden.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent e)
            {
                note.changeFont(note.getCurrentFont().getFontName(), Font.BOLD, note.getCurrentFont().getSize());
            }
        });

        JComboBox<Integer> fontSizeList = new JComboBox<Integer>(FONT_SIZES);
        fontSizeList.setSelectedIndex(3);
        fontSizeList.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent e)
            {
                note.changeFont(note.getCurrentFont().getFontName(), note.getCurrentFont().getStyle(), (int) fontSizeList.getSelectedItem());
            }
        });

        JComboBox<String> fontNameList = new JComboBox<String>(FONT_NAMES);
        fontNameList.setSelectedItem(1);
        fontNameList.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent e)
            {
                note.changeFont((String) fontNameList.getSelectedItem(), note.getCurrentFont().getStyle(), note.getCurrentFont().getSize());
            }
        });

    }
}
