using Microsoft.AspNetCore.Components.Forms;

namespace AdventOfCode2023.ApiService.Puzzles.Solutions;

public class Day3 : SolutionBase
{
    private const char _spacerChar = '.';
    
    private static int _rowCount = -1, _columnCount = -1;
    private static int _sum = 0, _leftBound = -1, _rightBound = -1;
    private static bool _collectingNumber = false, _leftBoundIsSpecial = false, _rightBoundIsSpecial = false;
    private static IList<char> _foundNumber = [];


    public Day3() : base(nameof(Day3))
    {
    }

    // think of input as 2 dimensional char array
    // for every input line

    // step through the input line

    // when a digit is encountered
        // record index - 1 (left bound)
        // step through until a digit is not encountered, record this index (right bound)
        // concat all the digits we have stepped through, this is the number
        // determine if the number is a 'part' number which we will keep and add to the sum
            // 1st, just check this input line
                // look at the two recorded indexes above, if a special char exists we keep number and go back to stepping through the line (start at right bound + 1)
            // 2nd, look at the input lines above and below
                // inspect every index, from the left bound, to the right bound and check for a special char, if found, keep number and continue stepping through original line
            // if no special char found, drop the number, it is NOT added to sum
    private protected override string InitialSolutionForPartOne(IList<string> puzzleInput)
    {
        _sum = 0;
        _rowCount = puzzleInput.Count;
        _columnCount = puzzleInput.First().Length;

        // verify length
        if (!puzzleInput.All(m => m.Length == _columnCount))
        {
            throw new InvalidOperationException();
        }

        for (int i = 0; i < _rowCount; i++)
        {
            // reset flags
            _leftBound = -1;
            _rightBound = -1;
            _collectingNumber = false;
            //_leftBoundIsSpecial = false;
            //_rightBoundIsSpecial = false;
            _foundNumber.Clear();

            for (int j = 0; j < _columnCount; j++)
            {
                // no number collection has started
                if (!_collectingNumber)
                {
                    if (puzzleInput[i][j] is _spacerChar) // empty space, reset possible special left bound, move on
                    {
                        //_leftBoundIsSpecial = false;
                        continue;
                    }
                    else if (!char.IsDigit(puzzleInput[i][j])) // special character, flag as possible special left bound
                    {
                        //_leftBoundIsSpecial = true;
                        continue;
                    }
                    else // we found the first digit of a number
                    {
                        _collectingNumber = true;
                        _leftBound = j - 1;
                        _foundNumber.Add(puzzleInput[i][j]);
                        continue;
                    }
                }
                else // we are now collecting a number
                {
                    // if we have another digit, append it to temp storage
                    if (char.IsDigit(puzzleInput[i][j]))
                    {
                        _foundNumber.Add(puzzleInput[i][j]);
                        
                        // continue processing this row
                        if (j != _columnCount - 1)
                        {
                            continue;
                        }
                    }
                    
                    // no more digits or we are at the end of the row
                    // stop number collection, record right bound
                    _collectingNumber = false;
                    _rightBound = j;

                    // flag both right bound and possible new left bound as special or not
                    //_rightBoundIsSpecial = _leftBoundIsSpecial = IsSpecialChar(puzzleInput[i][j]);

                    // determine if we should keep the number or not
                    // we already know if the immediate left/right bounds are special or not, check those first
                    // else look at surrounding area for special chars
                    // if we find a special char anywhere, add the number to our sum
                    if (SpecialCharNearby(rowIndex: i, puzzleInput))
                    {
                        _sum += int.Parse(new string(_foundNumber.ToArray()));
                    }

                    // clear temp storage
                    _foundNumber.Clear();
                }
            }
        }

        return $"{_sum}";
    }

    private protected override string FinalSolutionForPartTwo(IList<string> puzzleInput)
    {
        // TODO
        return string.Empty;
    }

    private static bool SpecialCharNearby(int rowIndex, IList<string> puzzleInput)
    {
        if (rowIndex is 0) // just check next row
        {
            return CurrentRowHasSpecialChar(rowIndex, puzzleInput) || NextRowHasSpecialChar(rowIndex, puzzleInput);
        }
        else if (rowIndex == _rowCount - 1) // just check previous row
        {
            return CurrentRowHasSpecialChar(rowIndex, puzzleInput) || PreviousRowHasSpecialChar(rowIndex, puzzleInput);
        }
        else // check both
        {
            return CurrentRowHasSpecialChar(rowIndex, puzzleInput) || PreviousRowHasSpecialChar(rowIndex, puzzleInput) || NextRowHasSpecialChar(rowIndex, puzzleInput);
        } 
    }

    private static bool CurrentRowHasSpecialChar(int rowIndex, IList<string> puzzleInput)
    {
        var (left, right) = SanitizeBounds();

        return IsSpecialChar(puzzleInput[rowIndex][left]) || IsSpecialChar(puzzleInput[rowIndex][right]);
    }

    private static bool NextRowHasSpecialChar(int rowIndex, IList<string> puzzleInput)
    {
        var (left, right) = SanitizeBounds();

        return puzzleInput[rowIndex + 1][left..(right + 1)].Any(IsSpecialChar);
    }

    private static bool PreviousRowHasSpecialChar(int rowIndex, IList<string> puzzleInput)
    {
        var (left, right) = SanitizeBounds();

        return puzzleInput[rowIndex - 1][left..(right + 1)].Any(IsSpecialChar);
    }

    private static (int left, int right) SanitizeBounds()
    {
        return (_leftBound < 0 ? 0 : _leftBound, _rightBound);
    }

    private static bool IsSpecialChar(char c)
    {
        return c is not _spacerChar && !char.IsDigit(c);
    }

    // maybe dont need this, just use the initial collection
    private static char[,] ConvertInputToTwoDimensionalArray(IList<string> input)
    {
        char[,] twoDimCharArray = new char[input.Count, input.First().Length];

        for (int i = 0; i < input.Count; i++)
        {
            for (int j = 0; j < input.First().Length; j++)
            {
                twoDimCharArray[i, j] = input[i][j];
            }
        }

        return twoDimCharArray;
    }
}
