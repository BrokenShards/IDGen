# IDGen
IDGen is a simple random idea generator using text files as word dictionaries.

## Usage

### Creating a new word pack
To create a new word pack, click the "New" button at the bottom of the Word Pack list and you will be prompted to
supply a name for the new word pack. Please note that the name of a word pack must be a valid file name. Once you have
supplied a valid name, you will be greeted with the pack editor, where you can modify the words in the pack.

### Importing an existing word pack
IDGen looks for word packs in the "[IDGen]/packs/" folder with the ".txt" file extention, so word packs can either be
imported manually by copying the .txt file to this folder, or using the import button on the main form (which will
change the file extention if necessary).

### Generating an idea.
When you have your packs loaded, click the '+' button next to the pack name in the word packs list in order to add it
to the pack stack. Currently if you would like to remove a pack from the pack stack, you must press the "Clear" button
at the bottom the clear the entire stack. I will implement pack stack re-orering and removing a single pack from the
stack in a future update.
Once you have the pack stack set up, press the "Generate" button at the bottom of the "Generated" panel in order to
generate a random idea using random words from each pack in the order given. I am hoping to add a hold and re-reroll
feature in a future update to easily modify parts of ideas.

### Word Packs
Word packs are .txt files containing a list of associated words seperated with a new line that are used to geneate ideas.

### Pack Stack
The pack stack is a list of which word packs to use to generate an idea in which order.

## Changelog

### Version 0.0.4a
Corrected bug where on closing the pack editor and selecting yes to save, the pack was not actually modified and saved.

### Version 0.0.3a
Corrected bug where pack editor was not actually modifying the current pack when save or save as was clicked.

### Version 0.0.2a
Implemented the basic functionality of the pack editor.
Now UI text is centered and wraps properly.
Improved look of UI
Made the generated box read-only.

### Version 0.0.1a
Initial release.
