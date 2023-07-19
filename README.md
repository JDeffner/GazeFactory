# GazeFactory
Diese Seite enthält den folgenden Inhalt:
- [Projektbeschreibung](#projektbeschreibung)
- [Nutzen von Gaze Guiding](#akw-und-gaze-guiding)
- [Umsetzung des Gaze Guidings](#umsetzung-des-gaze-guidings)

## Projektbeschreibung
Bei der GazeFactory handelt es sich um ein Informatikprojekt der Studenten [Christof Treitges](https://github.com/CTreitges), [Joël Deffner](https://github.com/JDeffner), [David Jacobs](https://github.com/DJacobs-dev) und [Justin Weich](https://github.com/1Houston1) der Universität Trier unter der Leitung von [Jun.-Prof. Dr.-Ing. Benjamin Weyers](https://www.uni-trier.de/universitaet/fachbereiche-faecher/fachbereich-iv/faecher/informatikwissenschaften/professuren/human-computer-interaction/team/benjamin-weyers).

Das Projekt handelt von der gezielten Blickführung eines Probanden in einer VR-Umgebung. Im folgenden wird für `Blickführung` der Fachbegriff `Gaze Guiding` oder kurz `GG` verwendet. Das Gaze Guiding wird anhand einer Atomkraftwerkssimulation vorgestellt, indem der Proband das Herauffahren eines AKWs vollbringen muss.

## AKW und Gaze Guiding
Die korrekte Bedienung eines AKWs ist nicht trivial. Das Zusammenspiel einzelner Komponenten und Parameter ist mitunter komplex und sensibel, Fehler können extreme Konsequenzen nach sich ziehen bis hin zu einer `Kernschmelze`. Genau darauf soll das `Gaze Guiding` vorbereiten, bzw. es gar nicht erst soweit kommen lassen. Das `GG` führt einen Probanden schrittweise durch die Simulation, es reagiert auf falsche Eingaben und lenkt den Blick auf den wichtigsten Schritt der als nächstes zu tätigen ist. Ein solches Training erweist sich als sinnvoll, wenn `Standardprozeduren`, sogenannte `SOP`s, oft in Vergessenheit geraten oder selten genutzt werden. Durch die Simulation wird bereits erlerntes Wissen aufgefrischt oder neues Wissen errungen.

Ausgelegt ist das Projekt für das Herrauffahren eines Atomkraftwerkes, sodass 2100 mm Wasser stabil im Reaktortank verbleiben und eine Energieausgabe von 700 MW ausgewiesen wird.

## Umsetzung des Gaze Guidings
Das `Gaze Guiding` wurde untergliedert in vier Arbeitsbereiche, die `SOP`s, das `Systemzustandsmodell`, kurz `SSM`, das `Gaze Guiding Model`, kurz `GGM` und die `Gaze Guiding Tools`, kurz `GGT`s. Die `SOP` des Herauffahren des AKWs lässt sich im `SSM` wiedererkennen, hier werden alle benötigten Schritte aufgezeigt und alle Fehlerzustände korrekt verwaltet. Das `GGM` verwaltet die `GGT`s auf Basis des `SSM`, das `SSM` wiederum erhält die Informationen aus der vorgelegten `SOP`. Bei den `GGT`s handelt es sich um einen `Text` (grün), dieser gibt an welcher Arbeitsschritt notwendig ist, einem `Ausrufezeichen` (grün), welches in unmittelbarer Nähe der auszuführenden Aktion schwebt und einer `Richtungserkennung`. Die `Richtungserkennung` ist nur dann aktiv, wenn das zu bedienende Objekt nicht im Sichtfeld ist. Der Sichtfeldrand blinkt rot in die Richtung, in die der Proband sich drehen muss, um das Bedienelement ins Sichtfeld zu bringen, dabei ist der Sichtfeldrand nicht nur für rechts und links ausgelegt, sondern für komplette 360°. Der `Text` und das `Ausrufezeichen` treten immer gemeinsam in räumlicher Nähe auf und besitzen weitere Eigenschaften:
- Fall 1: die zuvor getätigte Aktion war korrekt, es wurde dem `Gaze Guiding` gefolgt. Es tritt kein Sonderfall aus dem `SSM` ein, es wird der `SOP` gefolgt.
- Fall 2: die zuvor getätigte Aktion war entgegen des `Gaze Guidings`, `Text` und `Ausrufezeichen` wechseln die Farbe von grün zu orange.

Die Farbänderung wird vorgenommen um zusätzlich dem Probanden mitzuteilen, dass von der `SOP` abgewischen wurde.
