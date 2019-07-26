import { Injectable } from "@angular/core";

interface Scripts {
  name: string;
  src: string;
}

export const ScriptStore: Scripts[] = [
  {
    name: "jquery-admin",
    src: "../assets/admin/js/jquery-3.2.1.min.js"
  },
  { name: "popper", src: "../assets/admin/js/popper.min.js" },
  {
    name: "bootstrap",
    src: "../assets/admin/js/bootstrap.min.js"
  },
  {
    name: "perfectScrollbar",
    src: "../assets/admin/js/perfect-scrollbar.jquery.min.js"
  },
  { name: "wave", src: "../assets/admin/js/waves.js" },
  { name: "sticky-kit", src: "../assets/admin/js/sticky-kit.min.js" },
  { name: "sparkline", src: "../assets/admin/js/jquery.sparkline.min.js" },
  { name: "sidebarmenu-admin", src: "../assets/admin/js/sidebarmenu.js" },
  { name: "custom-admin", src: "../assets/admin/js/custom.min.js" },
  { name: "dataTable", src: "../assets/admin/js/jquery.dataTables.min.js" },
  { name: "dataTable-custom", src: "../assets/admin/js/dataTable-custom.js" },

  { name: "jquery-client", src: "../assets/js/jquery.min.js" },
  { name: "uniform-client", src: "../assets/js/jquery.uniform.min.js" },
  { name: "slicknav-client", src: "../assets/js/jquery.slicknav.min.js" },
  { name: "wow-client", src: "../assets/js/wow.min.js" },
  { name: "custom-client", src: "../assets/js/scripts.js" }
];

declare var document: any;

@Injectable()
export class DynamicScriptLoaderService {
  private scripts: any = {};

  constructor() {
    ScriptStore.forEach((script: any) => {
      this.scripts[script.name] = {
        loaded: false,
        src: script.src
      };
    });
  }

  load(...scripts: string[]) {
    const promises: any[] = [];
    scripts.forEach(script => promises.push(this.loadScript(script)));
    return Promise.all(promises);
  }

  loadScript(name: string) {
    return new Promise((resolve, reject) => {
      if (!this.scripts[name].loaded) {
        //load script
        let script = document.createElement("script");
        script.type = "text/javascript";
        script.async = true;
        // script.defer = true;
        script.src = this.scripts[name].src;
        if (script.readyState) {
          //IE
          script.onreadystatechange = () => {
            if (
              script.readyState === "loaded" ||
              script.readyState === "complete"
            ) {
              script.onreadystatechange = null;
              this.scripts[name].loaded = true;
              resolve({ script: name, loaded: true, status: "Loaded" });
            }
          };
        } else {
          //Others
          script.onload = () => {
            this.scripts[name].loaded = true;
            resolve({ script: name, loaded: true, status: "Loaded" });
          };
        }
        script.onerror = (error: any) =>
          resolve({ script: name, loaded: false, status: "Loaded" });
        document.getElementsByTagName("head")[0].appendChild(script);
      } else {
        resolve({ script: name, loaded: true, status: "Already Loaded" });
      }
    });
  }
}
