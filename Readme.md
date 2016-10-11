# Save to stream and save to file behave differently when exporting to HTML

I'm using a [custom font](bebas-neue) (this is not the actual font I'm using but the problem is happening with this one too) in a `docx` (Word 2013) document. In order to reproduce this bug you need to change the font of the `Normal Style` to your custom font (the `\Runner\custom-font.docx` document exhibits this issue).

When saving to a stream, Spire replaces the custom font I'm using by the previous value of the `Normal Style` (`Calibri` in my case). When saving to a file directly, Spire preserves the custom font.

## Configuration

- Windows 7 Enterprise SP1 64-bit
  - Location: Australia
  - Format: English (Australia)
  - Display language: English
  - Keyboard: English (Australia) - US
- Visual Studio Premium 2013
- `Spire.Doc.dll` version `5.7.0.3040` (trial version)
- `Spire.License.dll` version `1.3.5.40`
- .NET 4.5

**Note**: I've tried using version `Spire.Doc.dll 5.7.117.3040` and `Spire.License.dll 1.3.5.40` which seems to be the latest version and obtained different results but the bug is still there albeit it's slightly different (it only impacts the inline CSS at the top).

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

The resulting HTML file has the custom font in `font-family` (see `out\<version>\file.html`).

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

The resulting HTML file has `Calibri,Arial` in `font-family` (instead of the custom font).

[bebas-neue]: http://www.dafont.com/bebas-neue.font