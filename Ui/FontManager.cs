using System;
using System.Collections.Generic;
using Com.Latipium.Core;
using Com.GitHub.DesotoHS.HallOfFame.Service;

namespace Com.GitHub.DesotoHS.HallOfFame.Ui {
    [LatipiumExportClass(0)]
    public class FontManager : LatipiumObject, IFontManager {
        [LatipiumImport]
        public IThemeService ThemeService;
        Dictionary<float, Font> Sizes = new Dictionary<float, Font>();

        [LatipiumExport]
        public Font GetFont(float size) {
            if (Sizes.ContainsKey(size)) {
                return Sizes[size];
            } else {
                return Sizes[size] = new Font(ThemeService.Font, size);
            }
        }
    }
}
