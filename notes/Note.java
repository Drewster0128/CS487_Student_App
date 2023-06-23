package notes;

import javax.swing.JLabel;
import java.awt.Font;
import java.util.ArrayList;

public class Note
{
    public static final String DEFAULT_FONT = Font.SANS_SERIF;
    public static final int DEFAULT_STYLE = Font.PLAIN;
    public static final int DEFAULT_SIZE = 12;

    private String title;
    private ArrayList<JLabel> content;
    private int pointer;
    private Font currentFont;
    
    public Note(String title, ArrayList<JLabel> content)
    {
        setTitle(title);
        this.content = new ArrayList<JLabel>();
        this.pointer = 0;
        this.currentFont = new Font(Font.SANS_SERIF, Font.PLAIN, 12);
    }

    public void setTitle(String title)
    {
        this.title = title;
    }

    public void insertContent(String character)
    {
        JLabel content = new JLabel(character);
        content.setFont(currentFont);
        this.content.add(content);
    }

    public void changeFont(JLabel selection, String font, int style, int size)
    {
        if(font.equals(Font.MONOSPACED) || font.equals(Font.SANS_SERIF) || font.equals(Font.SERIF) || font.equals(Font.DIALOG) || font.equals(Font.DIALOG_INPUT))
        {
            if(style == Font.BOLD || style == Font.ITALIC || style == Font.PLAIN)
            {
                if(size > 0)
                {
                    selection.setFont(new Font(font, style, size));
                }
                else
                {
                    throw new IllegalArgumentException("Font size must be greater than 0");
                }
            }
            else
            {
                throw new IllegalArgumentException("Style is bold, italic, or plain");
            }
        }
        else
        {
            throw new IllegalArgumentException("Need a valid font");
        }
    }

    public void changeFont(String font, int style, int size)
    {
        
        if(font.equals(Font.MONOSPACED) || font.equals(Font.SANS_SERIF) || font.equals(Font.SERIF) || font.equals(Font.DIALOG) || font.equals(Font.DIALOG_INPUT))
        {
            if(style == Font.BOLD || style == Font.ITALIC || style == Font.PLAIN)
            {
                if(size > 0)
                {
                    this.currentFont = new Font(font, style, size);
                }
                else
                {
                    throw new IllegalArgumentException("Font size must be greater than 0");
                }
            }
            else
            {
                throw new IllegalArgumentException("Style is bold, italic, or plain");
            }
        }
        else
        {
            throw new IllegalArgumentException("Need a valid font");
        }
    }

    public Font getCurrentFont()
    {
        return this.currentFont;
    }
}