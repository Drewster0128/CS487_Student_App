package notes;

import java.util.HashMap;
import java.util.Map;

public class Style 
{
    private int fontSize;
    private int lineSpace;
    private String font;
    private boolean firstLineTab;
    private boolean bold;
    private boolean italic;
    private boolean underline;

    public Style()
    {
        this.fontSize = 12;
        this.lineSpace = 1;
        this.font = "Times New Roman";
        this.firstLineTab = false;
        this.bold = false;
        this.italic = false;
        this.underline = false;
    }

    public Style(HashMap<String, Object> tags)
    {    
        this.fontSize = 12;
        this.lineSpace = 1;
        this.font = "Times New Roman";
        this.firstLineTab = false;
        this.bold = false;
        this.italic = false;
        this.underline = false;

        for(Map.Entry<String, Object> tag : tags.entrySet())
        {
            if(tag.getKey().equals("fontsize"))
            {
                setFontSize(tag.getValue());
            }
            else if(tag.getKey().equals("linespace"))
            {
                setLineSpace(tag.getValue());
            }
            else if(tag.getKey().equals("font"))
            {
                setFont(tag.getValue());
            }
            else if(tag.getKey().equals("firstLineTab"))
            {
                setFirstLineTab(tag.getValue());
            }
            else if(tag.getKey().equals("bold"))
            {
                setBold(tag.getValue());
            }
            else if(tag.getKey().equals("italic"))
            {
                setItalic(tag.getValue());
            }
            else if(tag.getKey().equals("underline"))
            {
                setUnderline(tag.getValue());
            }
        }
    }

    public void setFontSize(Object fontSize)
    {
        if(fontSize instanceof Integer && (int) fontSize > 0)
        {
            this.fontSize = (int) fontSize;
        }
    }

    public int getFontSize()
    {
        return this.fontSize;
    }

    public void setLineSpace(Object lineSpace)
    {
        if(lineSpace instanceof Integer && (int) lineSpace > 0)
        {
            this.lineSpace = (int) lineSpace;
        }
    }

    public int getLineSpace()
    {
        return this.lineSpace;
    }

    public void setFont(Object font) //more to be added later
    {
        if(font instanceof String)
        {
            if(String.valueOf(font).equals("Times New Roman"))
            {
                this.font = "Times New Roman";
            }
            else if(String.valueOf(font).equals("Arial"))
            {
                this.font = "Arial";
            }
            else if(String.valueOf(font).equals("Calibri"))
            {
                this.font = "Calibri";
            }
        }
    }

    public String getFont()
    {
        return this.font;
    }

    public void setFirstLineTab(Object firstLineTab)
    {
        if(firstLineTab instanceof Boolean)
        {
            this.firstLineTab = (boolean) firstLineTab;
        }
    }

    public boolean getFirstLineTab()
    {
        return this.firstLineTab;
    }

    public void setBold(Object bold)
    {
        if(bold instanceof Boolean)
        {
            this.bold = (boolean) bold;
        }
    }

    public boolean getBold()
    {
        return this.bold;
    }

    public void setItalic(Object italic)
    {
        if(italic instanceof Boolean)
        {
            this.italic = (boolean) italic;
        }
    }

    public boolean getItalic()
    {
        return this.italic;
    }

    public void setUnderline(Object underline)
    {
        if(underline instanceof Boolean)
        {
            this.underline = (boolean) underline;
        }
    }

    public boolean getUnderline()
    {
        return this.underline;
    }

}
