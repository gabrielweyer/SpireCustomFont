# Save to stream and save to file behave differently when exporting to HTML

I'm using a [custom font][bebas-neue] (this is not the actual font I'm using but the problem is happening with this one too) in a `docx` (Word 2013) document. In order to reproduce this bug you need to change the font of the `Normal Style` to your custom font ([this document][template] exhibits the issue).

When saving to a stream, Spire replaces the custom font I'm using by the previous value of the `Normal Style` (`Calibri` in my case). When saving to a file directly, Spire preserves the custom font.

This issue has been fixed in `Spire.Doc 5.7.126`.

## Configuration

- Windows 7 Enterprise SP1 64-bit
  - Location: Australia
  - Format: English (Australia)
  - Display language: English
  - Keyboard: English (Australia) - US
- Visual Studio Premium 2013
- `Spire.Doc.dll` version `5.8.0.3040` (trial version)
- `Spire.License.dll` version `1.3.5.40`
- .NET 4.5

## Open the file and configure the HTML exporting

```chsarp
var document = new Document("custom-font.docx");
document.HtmlExportOptions.ImageEmbedded = true;
document.HtmlExportOptions.CssStyleSheetType = CssStyleSheetType.Internal;
```

## Save to file

```csharp
document.SaveToFile("file.html", FileFormat.Html);
```

Saved to `out\<version>\file.html`.

## Save to stream

### Via SaveToFile

```csharp
using (var fileStream = new FileStream("stream-via-savetofile.html", FileMode.Create, FileAccess.Write))
{
    document.SaveToFile(fileStream, FileFormat.Html);
}
```

Saved to `out\<version>\stream-via-savetofile.html`.

### Via SaveToStream

```csharp
using (var fileStream = new FileStream("stream-via-savetostream.html", FileMode.Create, FileAccess.Write))
{
    document.SaveToStream(fileStream, FileFormat.Html);
}
```

Saved to `out\<version>\stream-via-savetostream.html`.

[bebas-neue]: http://www.dafont.com/bebas-neue.font
[template]: Runner/custom-font.docx